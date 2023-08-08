using ApplicationBLL.Models;

namespace Application.Views.Blazor.Helpers
{
    public class TableHalper
    {
        public List<BlazorModel> DynamicList = new List<BlazorModel>();
        public List<BlazorModel> StaticList = new List<BlazorModel>();

        public int MinCount { get; set; }
        public int MaxCount { get; set; }
        public int PageNumber { get; set; }

        public void ConfigureHelper(List<BlazorModel> list)
        {
            MinCount = 0;
            MaxCount = 10;
            PageNumber = 1;

            StaticList = list;
            DynamicList = StaticList.Skip(MinCount).Take(MaxCount - MinCount).ToList();
        }

        public void NextPage()
        {
            MinCount += 10;
            MaxCount += 10;
            PageNumber++;

            DynamicList = StaticList.Skip(MinCount).Take(MaxCount - MinCount).ToList();
        }

        public void BackPage()
        {
            MinCount -= 10;
            MaxCount -= 10;
            PageNumber--;

            DynamicList = StaticList.Skip(MinCount).Take(MaxCount - MinCount).ToList();
        }

        public void GetLastPage()
        {
            DynamicList = StaticList.Skip(MinCount).Take(MaxCount - MinCount).ToList();
        }
    }
}
