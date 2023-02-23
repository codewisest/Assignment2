using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment2.Controllers
{
    public class J2Controller : ApiController
    {
        /// <summary>
        /// determines how many ways two dice can be rolled to give the value of 10.
        /// <example>api/J2/DiceGame/6/8 -> There are 5 ways to get the sum 10.</example>
        /// </summary>
        /// <param name="m">number of sides of one die</param>
        /// <param name="n">number of sides of the other die</param>
        /// <returns>a string message of the number of possibilties to get the sum of ten</returns>
        [HttpGet]
        [Route("api/j2/DiceGame/{m}/{n}")]
        public string DiceGame(int m, int n)
        {
            int countSumOfTen = 0;
            int twoDiceSum = 0;
            //for(int i = 1; i <= m; i++)
            //{
            //    for(i = 1; i <= n; i++)
            //    {
            //        if(m + n == 10)
            //        {
            //           sumOfTen++;
            //        }

            //    }
            //}

            // permutate the two dice
            for(int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    twoDiceSum = i + j;
                    if(twoDiceSum == 10)
                    {
                        countSumOfTen++;
                    }
                }
            }
            return "There are " + countSumOfTen + " ways to get the sum 10";
        }
    }
}
