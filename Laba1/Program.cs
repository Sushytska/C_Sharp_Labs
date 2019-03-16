using System;
using System.Diagnostics;

namespace Laba1
{
    class MainClass
    {

            public static void Main(string[] args)
            {
                Person person_1 = new Person("Korbutiak", "Tetiana", new DateTime(1985, 12, 13));
                Paper paper_1 = new Paper("City", person_1, new DateTime(2017, 12, 24));

                ResearchTeam researchTeam = new ResearchTeam("History", "Researches", 145, TimeFrame.TwoYears, new[] { paper_1 });
                Console.WriteLine(researchTeam.ToShortString());

                Console.WriteLine(researchTeam[TimeFrame.Year]);
                Console.WriteLine(researchTeam[TimeFrame.Long]);
                Console.WriteLine(researchTeam[TimeFrame.TwoYears]);


                Person person_2 = new Person("Sorovichak", "Inna", new DateTime(1996, 04, 13));
                Paper paper_2 = new Paper("КЕКК", person_2, new DateTime(2015, 01, 24));
                researchTeam.AddPaper(paper_1, paper_2);
                Console.WriteLine(researchTeam.ToString());
                Console.WriteLine(researchTeam.LastPyblicatcia());


                int row = 100;
                int col = 100;

                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                String[] papers1 = new string[row*col];
                for(int i=0;i< row * col; i++)
                {
                    papers1[i] = researchTeam.ToString();
                }
                stopWatch.Stop();
                TimeSpan ts = stopWatch.Elapsed;

                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    ts.Hours, ts.Minutes, ts.Seconds,
                    ts.Milliseconds);
                Console.WriteLine("RunTime one dimention: " + elapsedTime);





                Stopwatch stopWatch2 = new Stopwatch();
                stopWatch2.Start();
                String[,] papers2 = new string[row,col];
                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < col; j++)
                    {
                        papers2[i,j] = researchTeam.ToString();
                    }
                }
                stopWatch2.Stop();
                TimeSpan ts2 = stopWatch2.Elapsed;

                string elapsedTime2 = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    ts2.Hours, ts2.Minutes, ts2.Seconds,
                    ts2.Milliseconds);
                Console.WriteLine("RunTime two dimention_1: " + elapsedTime2);





                Stopwatch stopWatch3 = new Stopwatch();
                stopWatch3.Start();
                String[][] papers3 = new string[row][];
                for (int i = 0; i < row; i++)
                {
                    papers3[i] = new string[row];
                    for (int j = 0; j < col; j++)
                    {
                        papers3[i][j] = researchTeam.ToString();
                    }
                }
                stopWatch2.Stop();
                TimeSpan ts3 = stopWatch3.Elapsed;
 
                string elapsedTime3 = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    ts3.Hours, ts3.Minutes, ts3.Seconds,
                    ts3.Milliseconds);
                Console.WriteLine("RunTime two dimention_2: " + elapsedTime3);

            }

        }
}

