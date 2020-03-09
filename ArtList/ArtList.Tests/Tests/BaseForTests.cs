using ArtList.Tests.Helpers;
using System.Collections.Generic;

namespace ArtList.Tests.Tests
{
    public class BaseForTests
    {
        protected ListCreator ListCreator = new ListCreator();

        protected void PrepareListAndArtList(out List<int> list, out ArtList<int> artList, int count)
        {
            ListCreator.PrepareListAndArtList(out list, out artList, count);
        }
    }
}