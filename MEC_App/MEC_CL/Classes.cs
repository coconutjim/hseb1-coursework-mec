using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MEC_CL
{
    public delegate double function(double x);
    public delegate double NDfunction(params double[] x);
    public class FunctionsAndMath
    {
        public FunctionsAndMath()
        {
            ListFunc = new Dictionary<string, function>()
        {
            {"y = x*sin(x)",x => x*Math.Sin(x)},
            {"y = x",x => x},
            {"y = -0.1 * x * x + 10", x => -0.1 * x * x + 10}
        };
            ListFunc3D = new Dictionary<string, NDfunction>()
        {
            {"y=x1",x=>x[0]},
            {"y = x1 * (x1 + x2)", x => x[0]*(x[0]+x[1])},
            {"y=x1+e*x2",x=>x[0]+Math.E*x[1]},
        };
            ListFunc4D= new Dictionary<string, NDfunction>()
        {
            {"y = x1 * x2 * x3",x => x[0]*x[1]*x[2]},
            {"y = x1 * (x2 + x3)",x => x[0]*x[1]*x[2]},
            {"y = sin(x1) * (cos(x2) + tg(x3))",x => Math.Sin(x[0])*Math.Cos(x[1])*Math.Tan(x[2])},

        };
        }
        public Delegate ParsedOne { get; set; }
        public function Func { get; set; }
        public NDfunction NDfunc { get; set; }
        public double CallFunc(double x)
        {
            return (double)ParsedOne.DynamicInvoke(x);
        }
        public double CallFuncND(params double[] x)
        {
            return (double)ParsedOne.DynamicInvoke(x);
        }

        public static Dictionary<string, function> ListFunc { get; set; }
        public static Dictionary<string, NDfunction> ListFunc3D { get; set; }
        public static Dictionary<string, NDfunction> ListFunc4D { get; set; }
        //
        public static bool OmegaChanged { get; set; }
        public static double NewOmega { get; set; }
        public double Omega { get; set; }
        Random gen = new Random();
        double nextNumber;
        bool ifNextNumber;
        public double NewNumberWithOmega()
        {
            if (ifNextNumber)
            {
                ifNextNumber = false;
                return nextNumber * Omega;
            }
            else
            {
                double x, y, s;
                do
                {
                    y = 2 * gen.NextDouble() - 1;
                    x = 2 * gen.NextDouble() - 1;
                    s = x * x + y * y;
                } while (s >= 1 || s == 0);
                double part = Math.Sqrt(-2 * Math.Log(s) / s);
                nextNumber = y * part;
                ifNextNumber = true;
                return x * part * Omega;
            }
        }
    }
    public class Population
    {
        public Population()
        {
            FAM = new FunctionsAndMath();
        }
        Random gen = new Random();
        public FunctionsAndMath FAM { get; set; }
        //
        uint sGC, tGC, iC;
        int xmax;
        public uint SGC
        {
            get { return sGC; }
            set
            {
                if (value == 0)
                    throw new Exception();
                sGC = value;
            }
        }
        public uint TGC
        {
            get { return tGC; }
            set
            {
                if (value == 0)
                    throw new Exception();
                tGC = value;
            }
        }
        public uint IC
        {
            get { return iC; }
            set
            {
                if (value == 0)
                    throw new Exception();
                iC = value;
            }
        }
        public int Xmin { get; set; }
        public int Xmax
        {
            get { return xmax; }
            set
            {
                if (value < Xmin)
                    throw new Exception();
                xmax = value;
            }
        }
        public double[] Initialization()
        {
            double[] group = new double[IC];
            group[0] = Xmin + (Xmax - Xmin) * gen.NextDouble();
            for (int i = 1; i < group.Length; i++)
            {
                group[i] = Sides(group[0] + FAM.NewNumberWithOmega());
            }
            return group;
        }
        double Sides(double x)
        {
            if (x > Xmax)
                x = Xmax;
            if (x < Xmin)
                x = Xmin;
            return x;
        }
        public void SimilarTaxis(Billboard[] gl, double[][] sg, Billboard[][] sloc, double[][] tg, Billboard[][] tloc)
        {
            for (int i = 0; i < sg.Length; i++)
            {
                sg[i][0] = sg[i][sloc[i][0].Index];
                for (int j = 1; j < sg[i].Length; j++)
                {
                    sg[i][j] = Sides(sg[i][0] + FAM.NewNumberWithOmega());
                }
                sloc[i] = FormLocalBillboard(sg[i]);
                gl[i].Score = sloc[i][0].Score;
            }
            for (int i = 0; i < tg.Length; i++)
            {
                tg[i][0] = tg[i][tloc[i][0].Index];
                for (int j = 1; j < tg[i].Length; j++)
                {
                    tg[i][j] = Sides(tg[i][0] + FAM.NewNumberWithOmega());
                }
                tloc[i] = FormLocalBillboard(tg[i]);
                gl[i + sg.Length].Score = tloc[i][0].Score;
            }
        }
        public void Dissimilation(Billboard[] glob, double[][] sg, Billboard[][] sloc, double[][] tg, Billboard[][] tloc)
        {
            double min;
            double temp;
            double[] tempar;
            Billboard[] tempbb;
            for (int i = 0; i < sg.Length; i++)
                for (int j = sg.Length; j < glob.Length; j++)
                    if (glob[j].Score > glob[i].Score)
                    {
                        tempar = sg[glob[i].Index]; sg[glob[i].Index] = tg[glob[j].Index]; tg[glob[j].Index] = tempar;
                        tempbb = sloc[glob[i].Index]; sloc[glob[i].Index] = tloc[glob[j].Index]; tloc[glob[j].Index] = tempbb;
                        temp = glob[i].Score; glob[i].Score = glob[j].Score; glob[j].Score = temp;
                        min = glob[i].Score;
                        for (int z = 0; z < sg.Length; z++)
                            if (glob[z].Score < min)
                                min = glob[z].Score;
                        if (min == glob[i].Score)
                        {
                            sg[glob[i].Index] = Initialization();
                            sloc[glob[i].Index] = FormLocalBillboard(sg[glob[i].Index]);
                            glob[i].Score = sloc[glob[i].Index][0].Score;
                        }
                    }
        }
        public double FindMax(Billboard[] gbb)
        {
            double max = gbb[0].Score;
            for (int i = 0; i < gbb.Length; i++)
                if (gbb[i].Score > max)
                    max = gbb[i].Score;
            return max;
        }
        public double FindArg(Billboard[] gbb, Billboard[][] sbb, double[][] sg)
        {
            int x = gbb[0].Index;
            double max = gbb[0].Score;
            for (int i = 0; i < gbb.Length; i++)
                if (gbb[i].Score > max)
                {
                    max = gbb[i].Score;
                    x = gbb[i].Index;
                }
            return sg[x][sbb[x][0].Index];
        }
        public Billboard[] FormLocalBillboard(double[] group)
        {
            Billboard[] local = new Billboard[group.Length];
            double max = FAM.Func(group[0]);
            int index = 0;
            bool flag = false;
            for (int i = 0; i < group.Length; i++)
            {
                local[i] = new Billboard();
                local[i].Score = FAM.Func(group[i]);
                local[i].Index = i;
                if (local[i].Score > max) { if (i != 0) flag = true; index = i; max = local[i].Score; }
            }
            if (flag)
            {
                local[index].Score = local[0].Score; local[0].Score = max;
                local[index].Index = local[0].Index; local[0].Index = index;
            }

            return local;
        }


        public Billboard[] FormGlobalBillboard(Billboard[][] sloc, Billboard[][] tloc)
        {
            Billboard[] global = new Billboard[sloc.Length + tloc.Length];
            for (int i = 0; i < sloc.Length; i++)
            {
                global[i] = new Billboard();
                global[i].Score = sloc[i][0].Score;
                global[i].Index = i;
            }
            for (int i = sloc.Length; i < sloc.Length + tloc.Length; i++)
            {
                global[i] = new Billboard();
                global[i].Score = tloc[i - sloc.Length][0].Score;
                global[i].Index = i - sloc.Length;
            }
            return global;
        }
        #region ND
        int[] xmaxs;
        public int Dimension { get; set; }
        public int[] Xmins { get; set; }
        public int[] Xmaxs
        {
            get { return xmaxs; }
            set
            {
                for (int i = 0; i < value.Length; i++)
                    if (value[i] < Xmins[i])
                        throw new Exception();
                xmaxs = value;
            }
        }
        double Sides(double x, int dimNumb)
        {
            if (x > Xmaxs[dimNumb])
                x = Xmaxs[dimNumb];
            if (x < Xmins[dimNumb])
                x = Xmins[dimNumb];
            return x;
        }
        public double[][] InitializationND()
        {
            double[][] group = new double[IC][];
            group[0] = new double[Dimension - 1];
            for (int j = 0; j < group[0].Length; j++)
            {
                group[0][j] = Xmins[j] + (Xmaxs[j] - Xmins[j]) * gen.NextDouble();
            }
            for (int i = 1; i < group.Length; i++)
            {
                group[i] = new double[Dimension - 1];
                for (int j = 0; j < group[i].Length; j++)
                    group[i][j] = Sides(group[0][j] + FAM.NewNumberWithOmega(), j);
            }
            return group;
        }
        public void SimilarTaxis(Billboard[] gl, double[][][] sg, Billboard[][] sloc, double[][][] tg, Billboard[][] tloc)
        {
            for (int i = 0; i < sg.Length; i++)
            {
                sg[i][0] = sg[i][sloc[i][0].Index];
                for (int k = 1; k < sg[i].Length; k++)
                    for (int j = 0; j < sg[i][k].Length; j++)
                        sg[i][k][j] = Sides(sg[i][0][j] + FAM.NewNumberWithOmega(), j);
                sloc[i] = FormLocalBillboard(sg[i]);
                gl[i].Score = sloc[i][0].Score;
            }
            for (int i = 0; i < tg.Length; i++)
            {
                tg[i][0] = tg[i][tloc[i][0].Index];
                for (int k = 1; k < tg[i].Length; k++)
                    for (int j = 0; j < tg[i][k].Length; j++)
                        tg[i][k][j] = Sides(tg[i][0][j] + FAM.NewNumberWithOmega(), j);
                tloc[i] = FormLocalBillboard(sg[i]);
                gl[i + sg.Length].Score = tloc[i][0].Score;
            }
        }
        public void Dissimilation(Billboard[] glob, double[][][] sg, Billboard[][] sloc, double[][][] tg, Billboard[][] tloc)
        {
            double min;
            double temp;
            double[][] tempar;
            Billboard[] tempbb;
            for (int i = 0; i < sg.Length; i++)
                for (int j = sg.Length; j < glob.Length; j++)
                    if (glob[j].Score > glob[i].Score)
                    {
                        tempar = sg[glob[i].Index]; sg[glob[i].Index] = tg[glob[j].Index]; tg[glob[j].Index] = tempar;
                        tempbb = sloc[glob[i].Index]; sloc[glob[i].Index] = tloc[glob[j].Index]; tloc[glob[j].Index] = tempbb;
                        temp = glob[i].Score; glob[i].Score = glob[j].Score; glob[j].Score = temp;
                        min = glob[i].Score;
                        for (int z = 0; z < sg.Length; z++)
                            if (glob[z].Score < min)
                                min = glob[z].Score;
                        if (min == glob[i].Score)
                        {
                            sg[glob[i].Index] = InitializationND();
                            sloc[glob[i].Index] = FormLocalBillboard(sg[glob[i].Index]);
                            glob[i].Score = sloc[glob[i].Index][0].Score;
                        }
                    }
        }
        public Billboard[] FormLocalBillboard(double[][] group)
        {
            Billboard[] local = new Billboard[group.Length];
            double max = FAM.NDfunc(group[0]);
            int index = 0;
            bool flag = false;
            for (int i = 0; i < group.Length; i++)
            {
                local[i] = new Billboard();
                local[i].Score = FAM.NDfunc(group[i]);
                local[i].Index = i;
                if (local[i].Score > max) { if (i != 0) flag = true; index = i; max = local[i].Score; }
            }
            if (flag)
            {
                local[index].Score = local[0].Score; local[0].Score = max;
                local[index].Index = local[0].Index; local[0].Index = index;
            }

            return local;
        }
        #endregion
    }
    public struct Billboard
    {
        public double Score { get; set; }
        public int Index { get; set; }
    }
}
