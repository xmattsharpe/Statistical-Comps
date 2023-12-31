using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace statsProj1
{
    internal class Stats
    {

        static void Main(string[] args)
        {
            // standard deviation of the population is referred to as sigma 

            int[] stats = GrabScores();
            FindMean(stats);
            stanDeviation(stats);
            calc_Variance(stats);

            ask_User();





            Console.ReadKey();
        }

        public static int[] GrabScores()
        {
            int conversion = 0;


            Console.Write("Enter amt of stat scores: ");

            try
            {
                string user_scores = Console.ReadLine();
                conversion = Int32.Parse(user_scores);

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            int[] stats_scores = new int[conversion];

            for (int i = 0; i < conversion; i++)
            {
                Console.Write($"Enter stat score {i + 1}: ");
                string user_inputs = Console.ReadLine();
                stats_scores[i] = Int32.Parse(user_inputs);
            }

            return stats_scores;
        }

        public static double? FindMean(int[] placeHolder)
        {
            // base case
            int lengths = placeHolder.Length;
            double mean = 0;
            int sum = 0;
            if (lengths == 0)
            {
                return null;
            }

            else
            {

                for (int j = 0; j < lengths; j++)
                {
                    sum += placeHolder[j];
                    mean = sum / lengths;
                }
            }

            Console.WriteLine($"Mean: {mean}");
            return mean;
        }

        public static double? stanDeviation(int[] Sample)
        {
            // population standard deviation
            double mean = 0;
            double sum = 0;
            double root = 0;
            double difference = 0;

            // base case 
            int length = Sample.Length;
            if (length == 0)
            {
                return null;
            }

            else
            {

                for (int j = 0; j < length; j++)
                {
                    sum += Sample[j];

                }

                mean = sum / length;
            }

            for (int i = 0; i < length; i++)
            {
                difference = Sample[i] - mean;
                root += Math.Pow(difference, 2);
            }

            double differences_dividedByn = root / length;
            double sigma = Math.Sqrt(differences_dividedByn);

            Console.WriteLine($"Sigma is: {sigma}");
            return sigma;
        }

       
        public static double? calc_Variance(int[] Sample)
        {
            // fix this later using a helper function.....
            double mean = 0;
            double sum = 0;
            double root = 0;
            double difference = 0;

            // base case 
            int length = Sample.Length;
            if (length == 0)
            {
                return null;
            }

            else
            {

                for (int j = 0; j < length; j++)
                {
                    sum += Sample[j];

                }

                mean = sum / length;
            }

            for (int i = 0; i < length; i++)
            {
                difference = Sample[i] - mean;
                root += Math.Pow(difference, 2);
            }

            double differences_dividedByn = root / length;

            Console.WriteLine($"The variance is: {differences_dividedByn}");
            return differences_dividedByn;
        }


        public static double linRegression_Slope(int[] x_vals, int[] y_vals)
        {
            // Linear regression
            double sumX = 0;
            double sumY = 0;
            double sumXY = 0;
            double sum_x_squared = 0;
            int lengths = x_vals.Length;

            // x summation
            for (int i = 0; i < x_vals.Length; i++)
            {
                sumX += x_vals[i];
            }

            // y summation
            for (int i = 0; i < y_vals.Length; i++)
            {
                sumY += y_vals[i];
            }

            // XY summation
            for (int i = 0; i < x_vals.Length; i++)
            {
                sumXY += x_vals[i] * y_vals[i];
            }

            // X^2 summation
            for (int i = 0; i < x_vals.Length; i++)
            {
                sum_x_squared += Math.Pow(x_vals[i], 2);
            }

            double slope_val = (lengths * sumXY - sumX * sumY) / (lengths * sum_x_squared - Math.Pow(sumX, 2));

            return slope_val;

        }

        public static double linRegression_Y_INT(int[] xVals, int[] yVals, double slope)
        {
            int sumX = 0;
            int n = xVals.Length;
            int sumY = 0;
            // x summation
            for (int i = 0; i < xVals.Length; i++)
            {
                sumX += xVals[i];
            }

            // y summation
            for (int i = 0; i < yVals.Length; i++)
            {
                sumY += yVals[i];
            }

            double Y_Intercept = (sumY - slope * sumX) / n;

            return Y_Intercept;
        }

        public static void ask_User()
        {
            // X VALUES
            Console.Write("*LINEAR REGRESSION* How many elements are you entering for the X-Values? ");
              string input = Console.ReadLine();
                 int convert = Int32.Parse(input);
                     int[] X_Vals = new int[convert];

            for(int i=0; i < convert; i++)
            {
                Console.Write($"Enter data for spot {i + 1}: ");
                    string user_Input = Console.ReadLine();
                        int conversion = Int32.Parse(user_Input);
                             X_Vals[i] = conversion;
            }

             // Y VALUES
            Console.Write(" How many elements are you entering for the Y-Values? (This should be the same # as the X- Values");
                 string input2 = Console.ReadLine();
                     int convert2 = Int32.Parse(input);
                          int[] Y_Vals = new int[convert2];

            for (int i = 0; i < convert; i++)
            {
                Console.Write($"Enter corresponding data for spot {i + 1}: ");
                  string user_Inputs = Console.ReadLine();
                     int conversions = Int32.Parse(user_Inputs);
                        Y_Vals[i] = conversions;
            }

            double slope = linRegression_Slope(X_Vals, Y_Vals);
            double yIntercept = linRegression_Y_INT(X_Vals, Y_Vals, slope);

            // Print the results or use them as needed
            Console.WriteLine($"Linear Regression: y = {slope}x + {yIntercept}");
        }
    }
    }


