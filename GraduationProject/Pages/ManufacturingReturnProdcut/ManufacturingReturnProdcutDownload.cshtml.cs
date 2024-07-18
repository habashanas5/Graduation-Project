using GraduationProject.Infrastructures.Pdfs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GraduationProject.Pages.ManufacturingReturnProdcut
{
    public class ManufacturingReturnProdcutDownloadModel : PageModel
    {
        private readonly IPdfService _pdfService;
        public ManufacturingReturnProdcutDownloadModel(IPdfService pdfService)
        {
            _pdfService = pdfService;
        }
        public IActionResult OnGet(string? id)
        {
            string fileName = $"ManufacturingReturn-{Guid.NewGuid()}.pdf";
            string baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}";
            string htmlUrl = $"{baseUrl}/ManufacturingReturnProdcut/ManufacturingReturnProdcutPdf/{id}";
            byte[] pdfBytes = _pdfService.CreatePdfFromPage(htmlUrl, fileName);
            return File(pdfBytes, "application/pdf", fileName);
        }

    }
}
