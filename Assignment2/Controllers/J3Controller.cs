using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;

namespace Assignment2.Controllers
{
    public class J3Controller : ApiController
    {
        [HttpGet]
        [Route("api/J2/TuneHarp/{tuneCode}")]
        public List<string> TuneHarp(string tuneCode)
        {
            List<string> tuneNumbers = new List<string> { };
            List<string> tuneInstruction = new List<string> { };
            List<char> tuneOperatorList = new List<char> { };

            string[] result = tuneCode.Split('+', '-');


            for(int i = 0; i < tuneCode.Length; i++)
            {
                if (tuneCode[i] == '+' || tuneCode[i] == '-')
                {
                    tuneOperatorList.Add(tuneCode[i]);
                }
            }

            for(int i = 0; i < result.Length; i++)
            {
                tuneNumbers.Add(Regex.Match(result[i], @"\d+\.*\d*").Value);    
            }

            List<string> resultOnlyString = new List<string> { };
            string tuneOperator = "";

            for (int j = 1; j < result.Length; j++)
            {
                tuneOperator = tuneOperatorList[j - 1] == '+' ? "tighten" : "losen";

                resultOnlyString.Add(Regex.Replace(result[j - 1], @"(?<![a-zA-Z])[^a-zA-Z]|[^a-zA-Z](?![a-zA-Z])", ""));
                tuneInstruction.Add(resultOnlyString[j-1] + " " + tuneOperator + " " + tuneNumbers[j]);
            }
            return tuneInstruction;
        }
    }
}


// I got this error while trying to test my code
// The request filtering module is configured to deny a request that contains a double escape sequence.

// To work around it I modified the web config by adding the following code to system.webservers
//  < security >
//    < requestFiltering allowDoubleEscaping = "true" > </ requestFiltering >
//  </ security >

// repl = Regex.Replace(input, @"(?<![a-zA-Z])[^a-zA-Z]|[^a-zA-Z](?![a-zA-Z])", "");