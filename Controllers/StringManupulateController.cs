using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleAPI1.Dto;

namespace SampleAPI1.Controllers
{
    [Route("api/v1")]
    [ApiController]
    public class StringManupulateController : ControllerBase
    {

        [HttpGet("string/functions")]
        public ActionResult Countcharacters()
        {
            return Ok(new List<object> { new { count = "will count number of characters" },
                                         new { isPanlindrome = "return yes if it is a palindrome" },
                                         new { capitalizeVowels = "it will capitalize all the vowels in the string" },
                                         new { deleteVowels = "it will delete all the vowels in the string" }});

        }


        [HttpPost("count")]
        public ActionResult count(StringManipulateDto data)
        {
            int answer = data.stringdata.Length;
            return Ok(new List<object> {new {response = answer}});

        }



        [HttpPost("isPanlindrome")]
        public ActionResult isPanlindrome(StringManipulateDto data)
        {
            string? s = data.stringdata;
            int size = s.Length;
            string? answer = "true"; 
            for (int i = 0; i < size / 2; i++)
            {

                if (s[i] != s[size - 1 - i])
                {
                    answer = "false";
                }

            }
            return Ok(new List<object> { new { response = answer } });

        }



        [HttpPut("capitalizeVowels")]
        public ActionResult capitalizeVowels(StringManipulateDto data)
        {
            string?  answer = "";
            string? s = data.stringdata;
            foreach (var i in s)
            {
                if (StringManupulateController.IsVowel(i) && i != ' ')
                {
                    answer = answer + Char.ToUpper(i); 
                }
                else
                {
                    answer = answer + i;
                }
            }
            return Ok(new List<object> { new { response = answer } });

        }


        [HttpDelete("deleteVowels")]
        public ActionResult deleteVowels(StringManipulateDto data)
        {
            
            string? s = data.stringdata;

            string? answer = "";

            foreach (char c in s)
            {
                if (!StringManupulateController.IsVowel(c))
                {
                    answer = answer + c;
                }
            }
            return Ok(new List<object> { new { response = answer} });

        }






        public static bool IsVowel(char c)
        {
            char[] arr = { 'A', 'E', 'I', 'O', 'U' };
            c = Char.ToUpper(c);
            foreach (char i in arr)
            {
                if (c == i)
                {
                    return true;
                }
            }
            return false;

        }
    }
}
