using AutoMapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using WebApp.BusinessLogic.DBModel;
using WebApp.Domain.Entities.Comp;
using WebApp.Domain.Entities.DatabaseTables;
using WebApp.Domain.Entities.Response;

namespace WebApp.BusinessLogic.Core
{
    public class AdminAPI
    {

        public ActionStatus CreateCard(CoCard card, HttpPostedFileBase photofile, HttpPostedFileBase pdffile)
        {
            try
            {
                // Check for duplicate card titles
                using (var db = new CardContext())
                {
                    bool cardExists = db.Cards.Any(e => e.title == card.title);
                    if (cardExists)
                    {
                        return new ActionStatus
                        {
                            IsSuccess = false,
                            StatusMessage = "There is already a card with this title",
                            SessionKey = "",
                        };
                    }
                }

                // Handle the image file upload
                if (photofile != null && photofile.ContentLength > 0)
                {
                    string photoFilename = Path.GetFileName(photofile.FileName);
                    string photoFilepath = Path.Combine(HttpContext.Current.Server.MapPath("~/Uploads/Images"), photoFilename);
                    photofile.SaveAs(photoFilepath);

                    // Convert the uploaded image to byte array
                    byte[] imageBytes = File.ReadAllBytes(photoFilepath);
                    card.img = imageBytes;
                }
                else
                {
                    card.img = null; // Handle no image uploaded
                }

                // Handle the PDF file upload
                if (pdffile != null && pdffile.ContentLength > 0)
                {
                    string pdfFilename = Path.GetFileName(pdffile.FileName);
                    string pdfFilepath = Path.Combine(HttpContext.Current.Server.MapPath("~/Uploads/PDFs"), pdfFilename);
                    pdffile.SaveAs(pdfFilepath);

                    // Convert the uploaded PDF to byte array
                    byte[] pdfBytes = File.ReadAllBytes(pdfFilepath);
                    card.pdf_file = pdfBytes;
                }
                else
                {
                    card.pdf_file = null; // Handle no PDF uploaded
                }

                // Map to the database entity
                var new_card = Mapper.Map<CoCardDBTable>(card);

                // Save to the database
                using (var db = new CardContext())
                {
                    db.Cards.Add(new_card);
                    db.SaveChanges();
                }

                return new ActionStatus { IsSuccess = true, StatusMessage = "200 OK", SessionKey = "" };
            }
            catch (Exception ex)
            {
                return new ActionStatus { IsSuccess = false, StatusMessage = $"An error occurred: {ex.Message}", SessionKey = "" };
            }
        }



       
    }
}