using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Project2
{
    class Program
    {
        static void Main(string[] args)
        {
            FileReader();
            Console.ReadLine();
        }

        public static void FileReader()
        {
            List<SuperBowl> superBowls = new List<SuperBowl>();
            SuperBowl aSuperbowl;
            const char DELIMITER = ',';
            string[] values;
            const string PATH = @"C:\Users\chushaa\Documents\Visual Studio 2017\Projects\Project2\Super_Bowl_Project.csv";

            try
            {
                FileStream file = new FileStream(PATH, FileMode.Open, FileAccess.Read);
                StreamReader read = new StreamReader(file);

                while (!read.EndOfStream)
                {
                    values = read.ReadLine().Split(DELIMITER);
                    aSuperbowl = new SuperBowl(values[0], values[1], Convert.ToInt32(values[2]), values[3], values[4], values[5], Convert.ToInt32(values[6]), values[7], values[8], values[9], Convert.ToInt32(values[10]), values[11], values[12], values[13], values[14]);
                    superBowls.Add(aSuperbowl);
                }
                read.Close();
                file.Close();
            }
            catch(Exception i)
            {
                Console.WriteLine(i.Message);
            }
            listOfWinners(superBowls);
            topFiveAttended(superBowls);
            mostHosted(superBowls);
            twiceMVP(superBowls);
            coachStats(superBowls);
            teamStats(superBowls);
            biggestDifference(superBowls);
            averageAttendance(superBowls);
        }
        public static void listOfWinners(List<SuperBowl> superbowls)
        {
            int x = 0;
            int difference = 0;

            Console.WriteLine("List of all Super Bowl Winners");
            Console.WriteLine("---------------------------------------------");

            while (x < superbowls.Count)
            {
                Console.WriteLine("Winning Team: " + superbowls[x].winner);
                Console.WriteLine("Date:" + superbowls[x].date);
                Console.WriteLine("Winning Quarterback: " + superbowls[x].qbWinner);
                Console.WriteLine("Winning Coach: " + superbowls[x].coachWinner);
                Console.WriteLine("MVP: " + superbowls[x].mvp);
                difference = superbowls[x].winningPoints - superbowls[x].losingPoints;
                Console.WriteLine("The Difference was: " + difference);
                Console.WriteLine();
                x++;
            }

            Console.WriteLine("----------------------------------------------");
        }
        public static void topFiveAttended(List<SuperBowl> superbowls)
        {
            int x = 0;

            List<SuperBowl> topFive = new List<SuperBowl>();

            topFive.Add(superbowls[x]);
            topFive.Add(superbowls[x]);
            topFive.Add(superbowls[x]);
            topFive.Add(superbowls[x]);
            topFive.Add(superbowls[x]);

            x = 1;

            while(x < superbowls.Count)
            {
                if(superbowls[x].attendence > topFive[0].attendence)
                {
                    topFive[0] = topFive[1];
                    topFive[1] = topFive[2];
                    topFive[2] = topFive[3];
                    topFive[3] = topFive[4];
                    topFive[0] = superbowls[x];
                }
                else if (superbowls[x].attendence > topFive[1].attendence)
                {
                    topFive[1] = topFive[2];
                    topFive[2] = topFive[3];
                    topFive[3] = topFive[4];
                    topFive[1] = superbowls[x];
                }
                else if (superbowls[x].attendence > topFive[2].attendence)
                {
                    topFive[2] = topFive[3];
                    topFive[3] = topFive[4];
                    topFive[2] = superbowls[x];
                }
                else if (superbowls[x].attendence > topFive[3].attendence)
                {
                    topFive[3] = topFive[4];
                    topFive[3] = superbowls[x];
                }
                else if (superbowls[x].attendence > topFive[4].attendence)
                {
                    topFive[4] = superbowls[x];
                }
                x++;
            }

            x = 0;

            Console.WriteLine("List of Top 5 Attended Super Bowls");
            Console.WriteLine("---------------------------------------------");
            while (x < topFive.Count)
            {
                Console.WriteLine("Date:" + topFive[x].date);
                Console.WriteLine("Winning Team: " + topFive[x].winner);
                Console.WriteLine("Losing Team: " + topFive[x].loser);
                Console.WriteLine("City: " + topFive[x].city);
                Console.WriteLine("State: " + topFive[x].state);
                Console.WriteLine("Stadium: " + topFive[x].stadium);
                Console.WriteLine();
                x++;
            }
            Console.WriteLine("----------------------------------------------");
        }
        public static void mostHosted(List<SuperBowl> superbowls)
        {
            //Output the state that hosted the  most super bowls
            int x = 1;

            List<string> mostHosted = new List<string>();
            List<int> mostHostedNum = new List<int>();
            List<SuperBowl> mostHostedObject = new List<SuperBowl>();

            while (x < superbowls.Count)
            {
                if (mostHosted.Contains(superbowls[x].city) == true)
                {
                    mostHostedNum[mostHosted.IndexOf(superbowls[x].city)] += 1;
                }
                else
                {
                    mostHosted.Add(superbowls[x].city);
                    mostHostedNum.Add(1);
                    mostHostedObject.Add(superbowls[x]);
                }
                x++;
            }

            x = 1;
            int indexNum = 0;

            while (x < mostHostedNum.Count)
            {
                if (mostHostedNum[x] > mostHostedNum[x - 1])
                {
                    indexNum = x;
                }
                x++;
            }


            Console.WriteLine("City that hosted the most Super Bowls");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("City: " + mostHostedObject[indexNum].city);
            Console.WriteLine("State: " + mostHostedObject[indexNum].state);
            Console.WriteLine("Stadium: " + mostHostedObject[indexNum].stadium);
            Console.WriteLine();
            Console.WriteLine("----------------------------------------------");

        }
        public static void twiceMVP(List<SuperBowl> superbowls)
        {
            int x = 1;

            List<string> mvp = new List<string>();
            List<int> mvpNum = new List<int>();
            List<SuperBowl> mvpObject = new List<SuperBowl>();
            List<int> indexList = new List<int>();

            while (x < superbowls.Count)
            {
                if (mvp.Contains(superbowls[x].city) == true)
                {
                    mvpNum[mvp.IndexOf(superbowls[x].city)] += 1;
                }
                else
                {
                    mvp.Add(superbowls[x].city);
                    mvpNum.Add(1);
                    mvpObject.Add(superbowls[x]);
                }
                x++;
            }

            x = 1;

            while (x < mvpNum.Count)
            {
                if (mvpNum[x] > 2)
                {
                    indexList.Add(x);
                }
                x++;
            }

            x = 0;

            Console.WriteLine("2+ time MVPs");
            Console.WriteLine("---------------------------------------------");

            while (x < indexList.Count)
            {
                Console.WriteLine(mvp[indexList[x]]);
                Console.WriteLine();
            }
            Console.WriteLine("----------------------------------------------");
        }
        public static void coachStats(List<SuperBowl> superbowls)
        {
            int x = 1;

            //Find Most Won
            List<string> mostWon = new List<string>();
            List<int> mostWonNum = new List<int>();

            while (x < superbowls.Count)
            {
                if (mostWon.Contains(superbowls[x].coachWinner) == true)
                {
                    mostWonNum[mostWon.IndexOf(superbowls[x].coachWinner)] += 1;
                }
                else
                {
                    mostWon.Add(superbowls[x].city);
                    mostWonNum.Add(1);
                }
                x++;
            }

            x = 1;
            int indexNum = 0;

            while (x < mostWonNum.Count)
            {
                if (mostWonNum[x] > mostWonNum[x - 1])
                {
                    indexNum = x;
                }
                x++;
            }

            x = 1;
            //Find Most Lost
            List<string> mostLost = new List<string>();
            List<int> mostLostNum = new List<int>();

            while (x < superbowls.Count)
            {
                if (mostLost.Contains(superbowls[x].coachLoser) == true)
                {
                    mostLostNum[mostLost.IndexOf(superbowls[x].coachLoser)] += 1;
                }
                else
                {
                    mostLost.Add(superbowls[x].city);
                    mostLostNum.Add(1);
                }
                x++;
            }

            x = 1;
            int indexNum2 = 0;

            while (x < mostLostNum.Count)
            {
                if (mostLostNum[x] > mostLostNum[x - 1])
                {
                    indexNum2 = x;
                }
                x++;
            }


            Console.WriteLine("Coach that won/lost the most");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Won Most: " + mostWon[indexNum]);
            Console.WriteLine("Lost Most: " + mostLost[indexNum2]);
            Console.WriteLine();
            Console.WriteLine("----------------------------------------------");
        }
        public static void teamStats(List<SuperBowl> superbowls)
        {
            int x = 1;

            //Find Most Won
            List<string> mostWon = new List<string>();
            List<int> mostWonNum = new List<int>();

            while (x < superbowls.Count)
            {
                if (mostWon.Contains(superbowls[x].coachWinner) == true)
                {
                    mostWonNum[mostWon.IndexOf(superbowls[x].coachWinner)] += 1;
                }
                else
                {
                    mostWon.Add(superbowls[x].city);
                    mostWonNum.Add(1);
                }
                x++;
            }

            x = 1;
            int indexNum = 0;

            while (x < mostWonNum.Count)
            {
                if (mostWonNum[x] > mostWonNum[x - 1])
                {
                    indexNum = x;
                }
                x++;
            }

            x = 1;
            //Find Most Lost
            List<string> mostLost = new List<string>();
            List<int> mostLostNum = new List<int>();

            while (x < superbowls.Count)
            {
                if (mostLost.Contains(superbowls[x].coachLoser) == true)
                {
                    mostLostNum[mostLost.IndexOf(superbowls[x].coachLoser)] += 1;
                }
                else
                {
                    mostLost.Add(superbowls[x].city);
                    mostLostNum.Add(1);
                }
                x++;
            }

            x = 1;
            int indexNum2 = 0;

            while (x < mostLostNum.Count)
            {
                if (mostLostNum[x] > mostLostNum[x - 1])
                {
                    indexNum2 = x;
                }
                x++;
            }


            Console.WriteLine("Coach that won/lost the most");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Won Most: " + mostWon[indexNum]);
            Console.WriteLine("Lost Most: " + mostLost[indexNum2]);
            Console.WriteLine();
            Console.WriteLine("----------------------------------------------");
        }
        public static void biggestDifference(List<SuperBowl> superbowls)
        {
            int x = 0;
            int difference = 0;
            int biggestDifference = 0;

            while (x < superbowls.Count)
            {
                difference = superbowls[x].winningPoints - superbowls[x].losingPoints;
                if (difference > biggestDifference)
                {
                    biggestDifference = difference;
                }
                x++;
            }

            Console.WriteLine("The biggest difference was: " + difference);
            Console.WriteLine();
            Console.WriteLine("----------------------------------------------");
        }
        public static void averageAttendance(List<SuperBowl> superbowls)
        {
            int x = 0;
            int totalAttendence = 0;
            int averageAttendence;
            while (x < superbowls.Count)
            {
                totalAttendence += superbowls[x].attendence;
            }

            averageAttendence = totalAttendence / superbowls.Count;

            Console.WriteLine("The average attendence was " + averageAttendence;);
            Console.WriteLine("----------------------------------------------");
        }
    }
    class SuperBowl
    {
        public string date { get; set; }
        public string sbNum { get; set; }
        public int attendence { get; set; }
        public string qbWinner { get; set; }
        public string coachWinner { get; set; }
        public string winner { get; set; }
        public int winningPoints { get; set; }
        public string qbLoser { get; set; }
        public string coachLoser { get; set; }
        public string loser { get; set; }
        public int losingPoints { get; set; }
        public string mvp { get; set; }
        public string stadium { get; set; }
        public string city { get; set; }
        public string state { get; set; }

        public SuperBowl()
        {

        }
        public SuperBowl(string date, string sbNum, int attendence, string qbWinner, string coachWinner, string winner, int winningPoints, string qbLoser,
                         string coachLoser, string loser, int losingPoints, string mvp, string stadium, string city, string state)
        {
            this.date = date;
            this.sbNum = sbNum;
            this.attendence = attendence;
            this.qbWinner = qbWinner;
            this.coachWinner = coachWinner;
            this.winner = winner;
            this.winningPoints = winningPoints;
            this.qbLoser = qbLoser;
            this.coachLoser = coachLoser;
            this.loser = loser;
            this.losingPoints = losingPoints;
            this.mvp = mvp;
            this.stadium = stadium;
            this.city = city;
            this.state = state;
        }
    }
}