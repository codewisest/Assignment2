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
        /// <summary>
        /// provides instruction for tuning harp based on the input string
        /// <example>AFB+8HC-4 -> AFB tighten 8, HC loosen 4</example>
        /// </summary>
        /// <param name="tuneCode">string for tuning harp</param>
        /// <returns>List of strings of harp tuning code</returns>
        [HttpGet]
        [Route("api/J3/TuneHarp/{tuneCode}")]
        public List<string> TuneHarp(string tuneCode)
        {
            // create empty
            List<string> tuneNumbers = new List<string> { };
            List<string> tuneInstruction = new List<string> { };
            List<char> tuneOperatorList = new List<char> { };

            // split input string into array of strings
            string[] result = tuneCode.Split('+', '-');

            // get all the plus and minus operators in to the list
            for(int i = 0; i < tuneCode.Length; i++)
            {
                if (tuneCode[i] == '+' || tuneCode[i] == '-')
                {
                    tuneOperatorList.Add(tuneCode[i]);
                }
            }

            // extract numbers from each split string and add them to the list
            for(int i = 0; i < result.Length; i++)
            {
                tuneNumbers.Add(Regex.Match(result[i], @"\d+\.*\d*").Value);    
            }

            List<string> resultOnlyAlphabet = new List<string> { };
            string tuneOperator = "";


            for (int j = 1; j < result.Length; j++)
            {
                // dynamically set value fo tune operator i.e tighten or losen
                tuneOperator = tuneOperatorList[j - 1] == '+' ? "tighten" : "loosen";

                // extract only alphabets from the split strings
                resultOnlyAlphabet.Add(Regex.Replace(result[j - 1], @"(?<![a-zA-Z])[^a-zA-Z]|[^a-zA-Z](?![a-zA-Z])", ""));

                // add the tune instructions
                tuneInstruction.Add(resultOnlyAlphabet[j-1] + " " + tuneOperator + " " + tuneNumbers[j]);
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