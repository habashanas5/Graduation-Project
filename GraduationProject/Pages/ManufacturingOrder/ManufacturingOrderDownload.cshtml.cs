using GraduationProject.Infrastructures.Pdfs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GraduationProject.Pages.ManufacturingOrder
{
    public class PurchaseOrderDownloadModel : PageModel
    {
        private readonly IPdfService _pdfService;
        public PurchaseOrderDownloadModel(IPdfService pdfService)
        {
            _pdfService = pdfService;
        }
        public IActionResult OnGet(string? id)
        {
            string fileName = $"ManufacturingOrder-{Guid.NewGuid()}.pdf";
            string baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}";
            string htmlUrl = $"{baseUrl}/ManufacturingOrder/ManufacturingOrderPdf/{id}";
            byte[] pdfBytes = _pdfService.CreatePdfFromPage(htmlUrl, fileName);
            return File(pdfBytes, "application/pdf", fileName);
        }

    }
}
