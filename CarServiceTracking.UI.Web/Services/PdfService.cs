using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using CarServiceTracking.UI.Web.ViewModels.Invoices;
using CarServiceTracking.UI.Web.ViewModels.Payments;
using CarServiceTracking.UI.Web.ViewModels.ServiceRequests;
using System.Globalization;

namespace CarServiceTracking.UI.Web.Services
{
    public class PdfService
    {
        private static readonly CultureInfo TrCulture = new("tr-TR");

        public byte[] GenerateInvoicePdf(InvoicePdfVM invoice)
        {
            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(40);
                    page.DefaultTextStyle(x => x.FontSize(10));

                    page.Header().Element(header =>
                    {
                        header.Row(row =>
                        {
                            row.RelativeItem().Column(col =>
                            {
                                col.Item().Text("FATURA").Bold().FontSize(24).FontColor(Colors.Blue.Darken2);
                                col.Item().Text($"Fatura No: {invoice.InvoiceNumber}").FontSize(12).FontColor(Colors.Grey.Darken1);
                            });

                            row.ConstantItem(180).AlignRight().Column(col =>
                            {
                                col.Item().Text("CarServiceTracking").Bold().FontSize(14);
                                col.Item().Text("Oto Servis Takip Sistemi").FontSize(9).FontColor(Colors.Grey.Darken1);
                                col.Item().Text($"Tarih: {DateTime.Now:dd.MM.yyyy}").FontSize(9).FontColor(Colors.Grey.Darken1);
                            });
                        });
                    });

                    page.Content().Element(content =>
                    {
                        content.PaddingVertical(15).Column(col =>
                        {
                            col.Item().LineHorizontal(1).LineColor(Colors.Grey.Lighten2);
                            col.Item().PaddingVertical(10).Row(row =>
                            {
                                row.RelativeItem().Column(left =>
                                {
                                    left.Item().Text("Müşteri Bilgileri").Bold().FontSize(12);
                                    left.Item().PaddingTop(5).Text($"Ad Soyad: {invoice.CustomerName}");
                                    left.Item().Text($"Telefon: {invoice.CustomerPhone}");
                                    left.Item().Text($"Araç: {invoice.CarInfo}");
                                });

                                row.RelativeItem().Column(right =>
                                {
                                    right.Item().Text("Fatura Bilgileri").Bold().FontSize(12);
                                    right.Item().PaddingTop(5).Text($"Fatura Tarihi: {invoice.InvoiceDate:dd.MM.yyyy}");
                                    right.Item().Text($"Vade Tarihi: {(invoice.DueDate.HasValue ? invoice.DueDate.Value.ToString("dd.MM.yyyy") : "-")}");
                                    right.Item().Text($"Ödeme Durumu: {GetPaymentStatusText(invoice.PaymentStatus)}");
                                });
                            });

                            col.Item().PaddingTop(15).Text("Tutar Detayları").Bold().FontSize(12);
                            col.Item().PaddingTop(5).Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn(3);
                                    columns.RelativeColumn(2);
                                });

                                table.Header(h =>
                                {
                                    h.Cell().Background(Colors.Blue.Darken2).Padding(8).Text("Açıklama").FontColor(Colors.White).Bold();
                                    h.Cell().Background(Colors.Blue.Darken2).Padding(8).AlignRight().Text("Tutar").FontColor(Colors.White).Bold();
                                });

                                AddTableRow(table, invoice.IsRentalInvoice ? "Kiralama Ücreti" : "İşçilik Ücreti", invoice.LaborCost, false);
                                AddTableRow(table, invoice.IsRentalInvoice ? "Depozito" : "Parça Toplamı", invoice.PartsTotal, false);
                                AddTableRow(table, "Ara Toplam", invoice.SubTotal, false);
                                AddTableRow(table, $"KDV (%{invoice.TaxRate:0})", invoice.TaxAmount, false);
                                AddTableRow(table, "GENEL TOPLAM", invoice.GrandTotal, true);
                                AddTableRow(table, "Ödenen Tutar", invoice.PaidAmount, false);
                                AddTableRow(table, "KALAN TUTAR", invoice.RemainingAmount, true);
                            });

                            if (!string.IsNullOrWhiteSpace(invoice.Notes))
                            {
                                col.Item().PaddingTop(15).Column(notesCol =>
                                {
                                    notesCol.Item().Text("Notlar").Bold().FontSize(11);
                                    notesCol.Item().PaddingTop(3).Text(invoice.Notes).FontColor(Colors.Grey.Darken2);
                                });
                            }
                        });
                    });

                    page.Footer().AlignCenter().Text(text =>
                    {
                        text.Span("Bu belge CarServiceTracking sistemi tarafından oluşturulmuştur. | ").FontSize(8).FontColor(Colors.Grey.Medium);
                        text.Span($"{DateTime.Now:dd.MM.yyyy HH:mm}").FontSize(8).FontColor(Colors.Grey.Medium);
                    });
                });
            });

            return document.GeneratePdf();
        }

        public byte[] GeneratePaymentReceiptPdf(PaymentEditVM payment)
        {
            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(40);
                    page.DefaultTextStyle(x => x.FontSize(10));

                    page.Header().AlignCenter().Column(col =>
                    {
                        col.Item().Text("ÖDEME MAKBUZU").Bold().FontSize(24).FontColor(Colors.Green.Darken2);
                        col.Item().Text("CarServiceTracking - Oto Servis Takip Sistemi").FontSize(10).FontColor(Colors.Grey.Darken1);
                    });

                    page.Content().Element(content =>
                    {
                        content.PaddingVertical(15).Column(col =>
                        {
                            col.Item().LineHorizontal(1).LineColor(Colors.Grey.Lighten2);

                            col.Item().PaddingVertical(15).Row(row =>
                            {
                                row.RelativeItem().Column(left =>
                                {
                                    left.Item().Text($"Makbuz No: #PM-{payment.Id}").Bold();
                                    left.Item().PaddingTop(5).Text($"Müşteri Adı: {payment.CustomerName}");
                                    left.Item().Text($"Fatura No: {payment.InvoiceNumber}");
                                });

                                row.RelativeItem().Column(right =>
                                {
                                    right.Item().Text($"Ödeme Tarihi: {payment.PaymentDate:dd.MM.yyyy HH:mm}").Bold();
                                    right.Item().PaddingTop(5).Text($"Ödeme Yöntemi: {GetPaymentMethodText(payment.PaymentMethod)}");
                                    right.Item().Text($"İşlem/Referans No: {(string.IsNullOrWhiteSpace(payment.TransactionId) ? "-" : payment.TransactionId)}");
                                });
                            });

                            col.Item().PaddingVertical(20).AlignCenter().Column(amountCol =>
                            {
                                amountCol.Item().AlignCenter()
                                    .Background(Colors.Green.Lighten4)
                                    .Border(1).BorderColor(Colors.Green.Darken1)
                                    .Padding(25)
                                    .Column(box =>
                                    {
                                        box.Item().AlignCenter().Text("ÖDENEN TUTAR").Bold().FontSize(12).FontColor(Colors.Green.Darken3);
                                        box.Item().AlignCenter().PaddingTop(5).Text(payment.Amount.ToString("C2", TrCulture)).Bold().FontSize(28).FontColor(Colors.Green.Darken3);
                                    });
                            });

                            if (!string.IsNullOrWhiteSpace(payment.Notes))
                            {
                                col.Item().PaddingTop(10).Column(notesCol =>
                                {
                                    notesCol.Item().Text("Notlar").Bold().FontSize(11);
                                    notesCol.Item().PaddingTop(3).Text(payment.Notes).FontColor(Colors.Grey.Darken2);
                                });
                            }
                        });
                    });

                    page.Footer().AlignCenter().Text(text =>
                    {
                        text.Span("Bu makbuz CarServiceTracking sistemi tarafından oluşturulmuştur. | ").FontSize(8).FontColor(Colors.Grey.Medium);
                        text.Span($"{DateTime.Now:dd.MM.yyyy HH:mm}").FontSize(8).FontColor(Colors.Grey.Medium);
                    });
                });
            });

            return document.GeneratePdf();
        }

        public byte[] GenerateServiceReportPdf(ServiceRequestDetailVM serviceRequest)
        {
            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(40);
                    page.DefaultTextStyle(x => x.FontSize(10));

                    page.Header().Element(header =>
                    {
                        header.Row(row =>
                        {
                            row.RelativeItem().Column(col =>
                            {
                                col.Item().Text("SERVİS RAPORU").Bold().FontSize(24).FontColor(Colors.Orange.Darken2);
                                col.Item().Text($"Talep No: #SR-{serviceRequest.Id}").FontSize(12).FontColor(Colors.Grey.Darken1);
                            });

                            row.ConstantItem(180).AlignRight().Column(col =>
                            {
                                col.Item().Text("CarServiceTracking").Bold().FontSize(14);
                                col.Item().Text($"Tarih: {DateTime.Now:dd.MM.yyyy}").FontSize(9).FontColor(Colors.Grey.Darken1);
                            });
                        });
                    });

                    page.Content().Element(content =>
                    {
                        content.PaddingVertical(15).Column(col =>
                        {
                            col.Item().LineHorizontal(1).LineColor(Colors.Grey.Lighten2);

                            col.Item().PaddingVertical(10).Text("Araç ve Talep Bilgileri").Bold().FontSize(12);
                            col.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn(1);
                                    columns.RelativeColumn(2);
                                });

                                AddInfoRow(table, "Araç", serviceRequest.CarName);
                                AddInfoRow(table, "Talep Tarihi", serviceRequest.CreatedAt.ToString("dd.MM.yyyy HH:mm"));
                                AddInfoRow(table, "Tercih Edilen Tarih", serviceRequest.PreferredDate.HasValue ? serviceRequest.PreferredDate.Value.ToString("dd.MM.yyyy") : "-");
                                AddInfoRow(table, "Durum", serviceRequest.StatusText);
                            });

                            col.Item().PaddingTop(15).Text("Sorun Tanımı").Bold().FontSize(12);
                            col.Item().PaddingTop(5)
                                .Border(1).BorderColor(Colors.Grey.Lighten1)
                                .Background(Colors.Grey.Lighten4)
                                .Padding(12)
                                .Text(serviceRequest.ProblemDescription);

                            if (serviceRequest.ServicePrice.HasValue)
                            {
                                col.Item().PaddingTop(15).Row(row =>
                                {
                                    row.RelativeItem().Column(priceCol =>
                                    {
                                        priceCol.Item().Text("Servis Ücreti").Bold().FontSize(12);
                                        priceCol.Item().PaddingTop(3).Text(serviceRequest.ServicePrice.Value.ToString("C2", TrCulture)).FontSize(16).Bold().FontColor(Colors.Blue.Darken2);
                                    });
                                });
                            }

                            if (!string.IsNullOrWhiteSpace(serviceRequest.AdminNote))
                            {
                                col.Item().PaddingTop(15).Column(noteCol =>
                                {
                                    noteCol.Item().Text("Yönetici Notu").Bold().FontSize(12);
                                    noteCol.Item().PaddingTop(3).Text(serviceRequest.AdminNote).FontColor(Colors.Grey.Darken2);
                                });
                            }
                        });
                    });

                    page.Footer().AlignCenter().Text(text =>
                    {
                        text.Span("Bu rapor CarServiceTracking sistemi tarafından oluşturulmuştur. | ").FontSize(8).FontColor(Colors.Grey.Medium);
                        text.Span($"{DateTime.Now:dd.MM.yyyy HH:mm}").FontSize(8).FontColor(Colors.Grey.Medium);
                    });
                });
            });

            return document.GeneratePdf();
        }

        private static void AddTableRow(TableDescriptor table, string label, decimal amount, bool bold)
        {
            var bgColor = bold ? Colors.Grey.Lighten3 : Colors.White;

            table.Cell().Background(bgColor).BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(8).Text(text =>
            {
                var span = text.Span(label);
                if (bold) span.Bold();
            });

            table.Cell().Background(bgColor).BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(8).AlignRight().Text(text =>
            {
                var span = text.Span(amount.ToString("C2", TrCulture));
                if (bold) span.Bold();
            });
        }

        private static void AddInfoRow(TableDescriptor table, string label, string value)
        {
            table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(8).Text(label).Bold().FontColor(Colors.Grey.Darken1);
            table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(8).Text(value);
        }

        private static string GetPaymentStatusText(string status)
        {
            return status switch
            {
                "Pending" => "Beklemede",
                "PartiallyPaid" => "Kısmi Ödendi",
                "Paid" => "Ödendi",
                "Overdue" => "Gecikmiş",
                _ => status
            };
        }

        private static string GetPaymentMethodText(string method)
        {
            return method switch
            {
                "Cash" => "Nakit",
                "CreditCard" => "Kredi Kartı",
                "DebitCard" => "Banka Kartı",
                "BankTransfer" => "Havale/EFT",
                _ => method
            };
        }
    }
}
