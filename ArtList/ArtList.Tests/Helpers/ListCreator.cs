using System.Collections.Generic;

namespace ArtList.Tests.Helpers
{
    public class ListCreator
    {
        public void PrepareListAndArtList(out List<int> list, out ArtList<int> artList, int count)
        {
            artList = new ArtList<int>();
            list = new List<int>();

            for (int i = 0; i < count; i++)
            {
                artList.Add(i);
                list.Add(i);
            }
        }
    }
}