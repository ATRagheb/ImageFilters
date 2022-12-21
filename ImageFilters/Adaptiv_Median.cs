using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using ZGraphTools;

namespace ImageFilters
{
    public partial class Adaptiv_Median : Form
    {
        static byte[,] countImageMatrix;
        static byte[,] quickImageMatrix;


        int sizeOfTmpMatrix = 3; //n(1)
        List<byte> countOneDimension = new List<byte>(); // O(1)
        List<byte> quickOneDimension = new List<byte>(); // O(1)
        List<double> countRunningTimeList = new List<double>(); //O(1)
        List<double> QuickRunningTimeList = new List<double>(); // O(1)

        public Adaptiv_Median(byte[,] image)
        {
            countImageMatrix = image; // O(1)
            quickImageMatrix = image; // O(1)
            InitializeComponent();
        }
        void PixelPicker(int N_value, byte[,] imageMatrix, List<byte> oneD, List<double> RunningTimeList, int choice)   //O(H*W*M)
        {
            if (choice == 1)
            {
                countRunningTimeList.Clear();
            }
            else if (choice == 2)
            {
                QuickRunningTimeList.Clear();
            }

            int[] sorted;       //O(1)
            for (int i = 0; i < imageMatrix.GetLength(0); i++)       // O(H * W * M)          H = height of the photo
            {
                for (int j = 0; j < imageMatrix.GetLength(1); j++)     // O(W * M)          W = Width of the photo
                {
                    bool pixelDone = false;         //O(1)
                    sizeOfTmpMatrix = 3;            //O(1)

                    while (pixelDone == false && sizeOfTmpMatrix <= N_value) //O(M)
                    {
                        Stopwatch stopwatch = new Stopwatch();
                        stopwatch.Start();

                        oneD.Clear();
                        convertToOneDimension(imageMatrix, oneD, i, j); // O(M)  M = size of frame(N) ^ 2
                        sorted = new int[oneD.Count]; //O(1)

                        if (choice == 1)
                        {
                            countSort(sorted, oneD); //O(N+k) size of One Dimension List(N) + maximum value in the list(K)
                        }
                        else if (choice == 2)
                        {
                            quicksort(oneD, 0, oneD.Count - 1); //exact (NLogN) best (NlogN) worst (M) 

                            for (int e = 0; e < oneD.Count; e++) //O(M)
                            {
                                sorted[e] = oneD[e]; //O(1)
                            }
                        }

                        pixelDone = adaptiveFilter(imageMatrix, i, j, sorted); //O(1)

                        stopwatch.Stop();
                        TimeSpan countts = stopwatch.Elapsed;
                        timeUpdater(RunningTimeList, countts);
                        // end of calculations
                    }

                }
            }
        }


        void timeUpdater(List<double> total, TimeSpan ts) //O(1)
        {
            int tmp = (sizeOfTmpMatrix - 3) / 2; //O(1)
            if (tmp > total.Count - 1)
            {
                total.Add(ts.TotalMilliseconds); //O(1)
            }
            else
            {
                total[tmp] += ts.TotalMilliseconds; //O(1)
            }
        }

        bool adaptiveFilter(byte[,] imageMatrix, int i, int j, int[] sorted) //O(1)
        {

            int min = sorted[0]; //O(1)
            int max = sorted[sorted.Length - 1]; //O(1)
            int middleIndex = sorted.Length / 2; //O(1)

            int med = sorted[middleIndex]; //O(1)
            int x = imageMatrix[i, j]; //O(1)


            int medTestA = med - min; //O(1)
            int medTestB = max - med; //O(1)

            if (medTestA > 0 && medTestB > 0)
            {

                int XTestA = x - min; //O(1)
                int XTestB = max - x; //O(1)

                if (XTestA <= 0 || XTestB <= 0) // must be smaller than zero
                {

                    imageMatrix[i, j] = (byte)med; //O(1)

                }

                return true;

            }
            else
            {

                sizeOfTmpMatrix += 2; //O(1)
                return false; //O(1)
            }

        }
        void convertToOneDimension(byte[,] imageMatrix, List<byte> oneD, int i, int j)   //O(M)  M = size of frame(N)^2
        {
            
            for (int m = i - ((sizeOfTmpMatrix - 1) / 2); m <= i + ((sizeOfTmpMatrix - 1) / 2); m++)     //O(n^2)
            {
                for (int n = j - ((sizeOfTmpMatrix - 1) / 2); n <= j + ((sizeOfTmpMatrix - 1) / 2); n++)        //O(n)
                {
                    if (m >= 0 && m < imageMatrix.GetLength(0) && n >= 0 && n < imageMatrix.GetLength(1))   //O(1)
                    {
                        oneD.Add(imageMatrix[m, n]); //O(1)
                    }
                }
            }
        }

        void countSort(int[] sorted, List<byte> oneD)       // O(M+k)
        {
            
            /*Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();*/

            int max = 0; //O(1)

            for (int i = 0; i < oneD.Count; i++) //O(M)
            {

                if (oneD[i] > max) //O(1)
                    max = oneD[i]; //O(1)
            }

            int[] value = new int[max + 1];         //O(1)
            int n = oneD.Count;                   //O(1)
            Array.Clear(value, 0, value.Length);

            for (int i = 0; i < n; i++)         //O(N)
            {

                value[oneD[i]]++;               //O(1)

            }


            for (int i = 1; i < value.Length; i++) //O(K)       K: Maximum Number in 1D Array
            {

                value[i] = value[i - 1] + value[i];         //O(1)
            }

            Array.Clear(sorted, 0, sorted.Length);

            for (int i = 0; i < oneD.Count; i++)            //O(M)
            {
                sorted[value[oneD[i]] - 1] = oneD[i];           //O(1)
                value[oneD[i]]--;                               //O(1)
            }

        }

        int partition(List<byte> arr, int start, int end) //O(N)
        {
            int i = start; //O(1)
            int j = end; //O(1)
            int p = i; //O(1)

            while (true) // O(N) 
            {
                if (arr[i] >= arr[j] && i != j)
                {
                    int tempswap = arr[i]; //O(1)
                    arr[i] = arr[j]; //O(1)
                    arr[j] = (byte)tempswap; //O(1)

                    if (p == i)
                    {
                        p = j;//O(1)
                        i++; //O(1)
                    }
                    else if (p == j)
                    {
                        p = i; //O(1)
                        j--; //O(1)
                    }
                }

                else if (i == j)
                    break; //O(1)

                else
                {
                    if (p == i) j--; //O(1)
                    else if (p == j) i++; //O(1)
                }
            }

            //if (start < p - 1)
            //    quicksort(arr, start, p - 1);
            //if (p + 1 < end)
            //    quicksort(arr, p + 1, end);

            return p; //O(1)
        }

        void quicksort(List<byte> arr, int start, int end) //exact (NLogN) best (NlogN) worst (N^2) 
        {
            if (start < end)
            {
                int p = partition(arr, start, end); //O(N)
                quicksort(arr, start, p - 1);
                quicksort(arr, p + 1, end);
            }

        }

        private void btn_showAdaptive_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txt_nValue.Text.ToString()))
            {
                MessageBox.Show("You Must Enter The Value Of N First!");
                return;
            }

            int N_value = Convert.ToInt32(txt_nValue.Text); //O(1)
            PixelPicker(N_value, countImageMatrix, countOneDimension, countRunningTimeList, 1); //O(H * W * N ^ 2)
            ImageOperations.DisplayImage(countImageMatrix, pictBoxOut);
            PixelPicker(N_value, quickImageMatrix, quickOneDimension, QuickRunningTimeList, 2); // O(H*W*N^2)
        }

        private void Adaptiv_Median_Load(object sender, EventArgs e)
        {
            ImageOperations.DisplayImage(countImageMatrix, pictureBox1);
        }

        private void btn_ZGraph_Click(object sender, EventArgs e)
        {
            // Make up some data points from the N, N log(N) functions
            // int N = 40;

            Console.WriteLine(countRunningTimeList.Count); //O(1)
            double[] x_values = new double[countRunningTimeList.Count]; //O(1)
            double[] y_values_count = new double[countRunningTimeList.Count]; //O(1)
            double[] y_values_quick = new double[countRunningTimeList.Count]; //O(1)


            for (int j = 0; j < countRunningTimeList.Count; j++) //O(N)
            {

                if (j != 0)
                {
                    y_values_count[j] = countRunningTimeList[j] + y_values_count[j - 1]; //O(1)
                    y_values_quick[j] = QuickRunningTimeList[j] + y_values_quick[j - 1]; //O(1)
                }
                else
                {
                    y_values_count[j] = countRunningTimeList[j]; //O(1)
                    y_values_quick[j] = QuickRunningTimeList[j]; //O(1)
                }
                Console.WriteLine("countVal:{0}", y_values_count[j]); //O(1)
                //Console.WriteLine("counterCount:{0}", counterCountRunningTimeList[j]);
                Console.WriteLine("quickVal:{0}", y_values_quick[j]); //O(1)
                //Console.WriteLine("quickcounter:{0}", counterQuickRunningTimeList[j]);

                Console.WriteLine("------------------------------------------"); //O(1)

                x_values[j] = j + 3; //O(1)
            }

            //Create a graph and add two curves to it
            ZGraphForm ZGF = new ZGraphForm("Sample Graph", "Window size", "Execution time");
            ZGF.add_curve("Counting sort", x_values, y_values_count, Color.Red);
            ZGF.add_curve("Quick sort", x_values, y_values_quick, Color.Blue);
            ZGF.Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 back = new Form1();
            back.ShowDialog();
            this.Close();
        }
    }
}