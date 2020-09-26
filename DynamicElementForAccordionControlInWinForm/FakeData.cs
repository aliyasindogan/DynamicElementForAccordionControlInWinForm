using System.Collections.Generic;

namespace DynamicElementForAccordionControlInWinForm
{
    public class FakeData
    {
        public int Id { get; set; }//CategoryId
        public int SubCategoryID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryClassName { get; set; }
        private List<FakeData> fakeDatas { get; set; }

        public List<FakeData> CreateFakeDate()
        {
            List<FakeData> list = new List<FakeData>();
            list.Add(new FakeData { Id = 1, SubCategoryID = 0, CategoryName = "GEÇİŞ KONTROL", CategoryClassName = "uc1" });
            list.Add(new FakeData { Id = 2, SubCategoryID = 1, CategoryName = "MW301", CategoryClassName = "uc2" });
            list.Add(new FakeData { Id = 3, SubCategoryID = 2, CategoryName = "Cihaz İşlemler", CategoryClassName = "uc3" });
            list.Add(new FakeData { Id = 4, SubCategoryID = 3, CategoryName = "Cihaz Listesi", CategoryClassName = "uc4" });
            list.Add(new FakeData { Id = 5, SubCategoryID = 3, CategoryName = "Geçiş Olay Verileri", CategoryClassName = "uc5" });
            list.Add(new FakeData { Id = 6, SubCategoryID = 0, CategoryName = "ARAÇ GEÇİŞ KONTROL", CategoryClassName = "uc6" });
            list.Add(new FakeData { Id = 7, SubCategoryID = 1, CategoryName = "MW110", CategoryClassName = "uc7" });
            list.Add(new FakeData { Id = 8, SubCategoryID = 6, CategoryName = "MW305", CategoryClassName = "uc8" });
            list.Add(new FakeData { Id = 9, SubCategoryID = 6, CategoryName = "PTS", CategoryClassName = "uc9" });

            return list;
        }
    }
}