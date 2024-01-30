using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using BerserkCollection.Models;

namespace BerserkCollection.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            using (BerserkcollectionContext db = new BerserkcollectionContext())
            {
                var cards = db.Cards.ToList();
            }

            return View(GetCards());
        }

        [HttpPost]
        public void Index(List<Card> cards)
        {
            SaveCards(cards);
        }

        public List<Card> GetCards()
        {
            List<Card> cards = new List<Card>();
            string path = "./wwwroot/data/data.xlsx";

            FileInfo fileInfo = new FileInfo(path);
            ExcelPackage package = new ExcelPackage(fileInfo);
            ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault();

            int rows = worksheet.Dimension.Rows;

            for (int i = 2; i <= rows; i++)
            {
                var card = new Card();
                card.Number = Convert.ToInt32(worksheet.Cells[i, 1].Value);
                card.Name = worksheet.Cells[i, 2].Value.ToString();
                card.Count = Convert.ToInt32(worksheet.Cells[i, 3].Value);
                card.Image = worksheet.Cells[i, 5].Value.ToString();
                card.Element = worksheet.Cells[i, 9].Value.ToString();
                card.Currency = worksheet.Cells[i, 11].Value.ToString();
                card.Rare = worksheet.Cells[i, 7].Value.ToString();
                card.Set = worksheet.Cells[i, 6].Value.ToString();

                cards.Add(card);
            }

            return cards;
        }

        public List<Card> SaveCards(List<Card> inputCards)
        {
            string path = "./wwwroot/data/data.xlsx";

            FileInfo fileInfo = new FileInfo(path);
            using (ExcelPackage package = new ExcelPackage(fileInfo))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault();

                foreach (var card in inputCards)
                {
                    foreach (var cell in worksheet.Cells["B:C"])
                    {
                        if (cell.Value.ToString() == card.Name)
                        {
                            worksheet.Cells[cell.Start.Row, 3].Value = card.Count;
                            break;
                        }
                    }
                }

                package.Save();
            }
            return inputCards;
        }
    }
}