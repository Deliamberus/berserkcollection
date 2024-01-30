using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using BerserkCollection.Models;

namespace BerserkCollection.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(GetCards());
        }

        [HttpPost]
        public void Index(List<Card> cards)
        {
            SaveCards(cards);
        }

        public List<Card> GetCards()
        {
            using (BerserkcollectionContext db = new BerserkcollectionContext())
            {
                var cards = db.Cards.ToList();

                return cards;
            }            
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