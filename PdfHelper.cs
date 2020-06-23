using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System.Collections.Generic;
using System.IO;

namespace PdfHelper {
	public class PdfHelper {
		public static void MergePDFs (string targetPath, params string[] pdfs) {
			using (PdfDocument targetDoc = new PdfDocument()) {
				foreach (string pdf in pdfs) {
					using (PdfDocument pdfDoc = PdfReader.Open(pdf, PdfDocumentOpenMode.Import)) {
						for (int i = 0; i < pdfDoc.PageCount; i++) {
							targetDoc.AddPage(pdfDoc.Pages[i]);
						}
					}
				}
				if (pdfs.Length > 0) {
					targetDoc.Save(targetPath);
				}
			}
		}
		public static void MergePDFs (string targetPath, List<string> pdfs) => MergePDFs(targetPath, pdfs.ToArray());
		public static void MergePDFs<T> (string targetPath, params T[] pdfs) where T : Stream {
			using (PdfDocument targetDoc = new PdfDocument()) {
				foreach (T pdf in pdfs) {
					using (PdfDocument pdfDoc = PdfReader.Open(pdf, PdfDocumentOpenMode.Import)) {
						for (int i = 0; i < pdfDoc.PageCount; i++) {
							targetDoc.AddPage(pdfDoc.Pages[i]);
						}
					}
				}
				if (pdfs.Length > 0) {
					targetDoc.Save(targetPath);
				}
			}
		}
		public static void MergePDFs<T> (string targetPath, List<T> pdfs) where T : Stream => MergePDFs(targetPath, pdfs.ToArray());
	}
}
