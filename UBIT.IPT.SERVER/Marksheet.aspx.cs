using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using UBIT.IPT.SERVER.classes;
using Newtonsoft.Json;

namespace UBIT.IPT.SERVER
{
    public partial class Marksheet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]

        public static string GetMarksSheet()
        {

            string request = HttpContext.Current.Request.Params["request"];
            MarksInfo[] marksInfo = JsonConvert.DeserializeObject<MarksInfo[]>(request);

            int totalSubjects = 0;
            int marksSecured = 0;

            int minMarks = marksInfo[0].subjectMarksObtianed;
            string minMarksSubject = marksInfo[0].subjectName;

            int maxMarks = marksInfo[0].subjectMarksObtianed;
            string maxMarksSubject = marksInfo[0].subjectName;

            for (int i =0; i<marksInfo.Length; i++)
            {

                MarksInfo currentInfo = marksInfo[i];
                marksSecured += currentInfo.subjectMarksObtianed;
                totalSubjects += 1;


                if( currentInfo.subjectMarksObtianed < minMarks)
                {
                    minMarks = currentInfo.subjectMarksObtianed;
                    minMarksSubject = currentInfo.subjectName;

                }
                if (currentInfo.subjectMarksObtianed > maxMarks)
                {
                    maxMarks = currentInfo.subjectMarksObtianed;
                    maxMarksSubject = currentInfo.subjectName;
                }

            }

            float average = marksSecured / totalSubjects;

            Result result = new Result();
            result.minMarks = minMarks;
            result.minMarksSubject = minMarksSubject;
            result.maxMarks = maxMarks;
            result.maxMarksSubject = maxMarksSubject;
            result.average = average;

            string resultStr = JsonConvert.SerializeObject(result);

            return resultStr;
        }

    }
}