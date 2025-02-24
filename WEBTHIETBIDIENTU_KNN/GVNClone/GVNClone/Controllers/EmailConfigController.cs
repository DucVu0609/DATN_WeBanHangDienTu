﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GVNClone.Controllers
{
    public class EmailConfigController : AdminController
    {
        dbMarkLeoDataContext db = new dbMarkLeoDataContext();
        // GET: EmailConfig
        public ActionResult Index()
        {
            GetData();
            return View(db.MauEmails.ToList());
        }
        [HttpPost]
        public ActionResult ConfigEmail(int id) {
            return PartialView(db.MauEmails.SingleOrDefault(n => n.MaLoai.Equals(id)));
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditEmail(int? id, string contentEmail, string subjectEmail) {
            if (id == null)
            {
                return Json(new { statusCode = 404, message = "Không tồn tại mã mẫu email này!" });
            }
            var objEmail = db.MauEmails.SingleOrDefault(n => n.MaMauEmail.Equals(id));
            objEmail.ContentEmail = contentEmail;
            objEmail.SubjectEmail = subjectEmail;
            db.SubmitChanges();
            return Json(new { statusCode = 200, message = "Cấu hình Email thành công" });
        }
    }
}