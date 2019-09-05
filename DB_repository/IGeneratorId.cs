using System;
using System.Collections.Generic;
using System.Text;

namespace DB_repository
{
   public interface IGeneratorId
    {
        string generateTagId();

        string generateLabel();
    }

    public class GenerateId : IGeneratorId
    {
        public string generateLabel()
        {
            Random R = new Random();

            var next = R.Next(1,200);

            return next.ToString();
        }

        public string generateTagId()
        {
            Random R = new Random();

            long NUD_1Value = 1;
            long NUD_2Value = 999999999999999; //15-digit number

            var next = R.NextDouble();

            double v = NUD_1Value + (next * (NUD_2Value - NUD_1Value));

            long result = Convert.ToInt64(v);

            return result.ToString();
        }
    }
}
