using System;
using System.ComponentModel.Design;

namespace YouTubeVideoStats
{
    class Program
    {
        static void Main(string[] args)
        {
            int numVideos = getNumVideos();

            // Initialize arrays to store views, likes, and like percentages
            long[] views = new long[numVideos];
            long[] likes = new long[numVideos];
            double[] likePct = new double[numVideos];

            // Generate video statistics
            generateViews(views);
            generateLikes(views, likes);
            calculateLikePct(views, likes, likePct);

            // Display all statistics
            displayStats(views, likes, likePct);

            // Identify and display videos with most/least views and likes
            maxViews(views, likes, likePct);
            minViews(views, likes, likePct);
            maxLikes(views, likes, likePct);
            minLikes(views, likes, likePct);
        }

        // Method to get the number of videos to analyze
        static int getNumVideos()
        {
            int numVideos = 0;
            while (true)
            {
                Console.WriteLine(" ");
                Console.Write("Enter the amount of videos that will be selected from Youtube (min: 1 - max: 9): ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out numVideos))
                {
                    if (numVideos >= 1 && numVideos <= 9) //continue if input is in range
                    {
                        break;
                    }
                    else //error message
                    {
                        Console.WriteLine(" ");
                        Console.WriteLine("ERROR: ENTER BETWEEN 1 AND 9 VIDEOS. TRY AGAIN.");
                    }
                }
                else //backup error message
                {
                    Console.WriteLine("ERROR: ENTER BETWEEN 1 AND 9 VIDEOS. TRY AGAIN.");
                }
            }
            return numVideos;
        }

        // Method to generate random views for each video
        static void generateViews(long[] views)
        {
            Random rand = new Random();
            for (int i = 0; i < views.Length; i++) 
            {
                views[i] = randomLong(0, 100_000_000_000, rand);
            }
        }

        // Method to generate random likes based on the number of views
        static void generateLikes(long[] views, long[] likes)
        {
            Random rand = new Random();
            for (int i = 0; i < likes.Length; i++)
            {
                likes[i] = randomLong(0, views[i], rand);
            }
        }

        // Method to calculate the like percentage for each video
        static void calculateLikePct(long[] views, long[] likes, double[] likePct)
        {
            for (int i = 0; i < likePct.Length; i++)
            {
                if (views[i] > 0) //if views > 0, divide the likes by the views to get the percent
                {
                    likePct[i] = (double)likes[i] / views[i] * 100.0;
                }
                else
                {
                    likePct[i] = 0.0;
                }
            }
        }

        // Method to display the statistics for all videos
        static void displayStats(long[] views, long[] likes, double[] likePct)
        {
            Console.WriteLine("\n ");
            Console.WriteLine("{0,-10}{1,20}{2,20}{3,15}", "Video #", "Views", "\tLikes", "\tLike %");
            for (int i = 0; i < views.Length; i++) //lists the statistics for how many videos you choose
            {
                Console.WriteLine("Video #{0,-10}{1,20:N0}{2,20:N0}{3,14:N2}%", i + 1, views[i], likes[i], likePct[i]);
            }
            Console.WriteLine("\n ");
        }

        // Method to find and display the video with the most views
        static void maxViews(long[] views, long[] likes, double[] likePct)
        {
            long maxView = views[0];
            int index = 0;
            for (int i = 1; i < views.Length; i++)
            {
                if (views[i] > maxView) //finds the video with the highest number in the views variable
                {
                    maxView = views[i];
                    index = i;
                }
            }
            Console.WriteLine("Most Viewed Video");
            displaySingleVideo(index, views, likes, likePct, "views");
        }

        // Method to find and display the video with the least views
        static void minViews(long[] views, long[] likes, double[] likePct)
        {
            long minView = views[0];
            int index = 0;
            for (int i = 1; i < views.Length; i++)
            {
                if (views[i] < minView) //finds the video with the lowest number in the views variable
                {
                    minView = views[i];
                    index = i;
                }
            }
            Console.WriteLine("Least Viewed Video");
            displaySingleVideo(index, views, likes, likePct, "views");
        }

        // Method to find and display the video with the most likes
        static void maxLikes(long[] views, long[] likes, double[] likePct)
        {
            long maxLike = likes[0];
            int index = 0;
            for (int i = 1; i < likes.Length; i++)
            {
                if (likes[i] > maxLike) //finds the video with the highest number in the likes variable
                {
                    maxLike = likes[i];
                    index = i;
                }
            }
            Console.WriteLine("Most Liked Video");
            displaySingleVideo(index, views, likes, likePct, "likes");
        }

        // Method to find and display the video with the least likes
        static void minLikes(long[] views, long[] likes, double[] likePct)
        {
            long minLike = likes[0];
            int index = 0;
            for (int i = 1; i < likes.Length; i++)
            {
                if (likes[i] < minLike) //finds the video with the lowest number in the likes variable
                {
                    minLike = likes[i];
                    index = i;
                }
            }
            Console.WriteLine("Least Liked Video");
            displaySingleVideo(index, views, likes, likePct, "likes");
        }

        // Helper method to display statistics for a single video
        static void displaySingleVideo(int index, long[] views, long[] likes, double[] likePct, string toShow)
        {
            if (toShow == "views")
            {
                Console.WriteLine(
                    "Video #{0,-10}" +
                    "{1,20:N0} views",
                    index + 1,
                    views[index]
                );
                Console.WriteLine("\n");
            }
            else if (toShow == "likes")
            {
                Console.WriteLine(
                    "Video #{0,-10}" +
                    "{1,20:N0} likes",
                    index + 1,
                    likes[index]
                );
                Console.WriteLine("\n");
            }
        }

        // Helper method to generate a random long number between min and max
        static long randomLong(long min, long max, Random rand)
        {
            if (min == max)
                return min;

            // Generate a random double between 0.0 and 1.0
            double sample = rand.NextDouble();
            long result = (long)(min + (sample * (max - min)));

            return result;
        }
    }
}
