using System.Collections.Generic;

namespace DataStructures.Tests.Helpers
{
    public class ListsComparer
    {
        public bool IsEqual(List<int> list, ArtList<int> artList, out string comparisonResult)
        {
            if (list.Capacity != artList.Capacity)
            {
                comparisonResult = $"\nCapacities are not equal:" +
                                   $"\n\t{nameof(list)}.Capacity={list.Capacity}" +
                                   $"\n\t{nameof(artList)}.Capacity={artList.Capacity}";
                return false;
            }

            if (list.Count != artList.Count)
            {
                comparisonResult = $"\nCounts are not equal:" +
                                   $"\n\t{nameof(list)}.Count={list.Count}" +
                                   $"\n\t{nameof(artList)}.Count={artList.Count}";
                return false;
            }

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] != artList[i])
                {
                    comparisonResult = $"\nItems values are not equal at {i} index:" +
                                    $"\n\t{nameof(list)}[{i}]={list[i]}" +
                                    $"\n\t{nameof(artList)}[{i}]={artList[i]}";
                    return false;
                }
            }

            comparisonResult = string.Empty;
            return true;
        }
    }
}