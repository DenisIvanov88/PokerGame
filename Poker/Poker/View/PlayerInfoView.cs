using Poker.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.View
{
    public static class PlayerInfoView
    {
        public static void PrintAllNamesAndBets()
        {
            string[] allNames = PlayerController.GetAllNames();
            string[] allBalances = PlayerController.GetAllBalances().Select(x => x.ToString()).ToArray();

            int length = Math.Max(allNames.Select(x => x.Length).Max(), allBalances.Select(x => x.Length).Max()) + 1;

            StringBuilder sb = new StringBuilder("│" + FormatString(allNames, length));

            sb.Append("\n│" + FormatString(allBalances, length));
            Console.WriteLine(sb);
            
        }

        private static StringBuilder FormatString(string[] arr, int maxLength)
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var name in arr)
            {
                StringBuilder currentName = new StringBuilder(name);
                for (int i = 0; i < maxLength - name.Length; i++)
                {
                    currentName.Append(" ");
                }
                stringBuilder.Append(currentName + "│");
            }
            return stringBuilder;
        }
    }
}
