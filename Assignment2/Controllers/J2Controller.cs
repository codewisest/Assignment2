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
        [HttpGet]
        [Route("api/j2/dicepermutation/{m}/{n}")]
        public int DicePermutation(int m, int n)
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
            return countSumOfTen;
        }
    }
}
