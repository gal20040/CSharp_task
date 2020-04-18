using DataStructures.Tests.Helpers;
using System.Collections.Generic;

namespace DataStructures.Tests
{
    public class BaseTest
    {
        protected ListCreator ListCreator = new ListCreator();

        protected void PrepareListAndArtList(out List<int> list, out ArtList<int> artList, int count)
        {
            ListCreator.PrepareListAndArtList(out list, out artList, count);
        }
    }
}