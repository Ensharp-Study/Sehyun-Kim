﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using System.Threading.Tasks;
using LTT.View;
using LTT.Model;
using LTT.Constant;
using LTT.Controller;

namespace LTT.Controller
{
    public class LTT
    {
        public static void Main(String[] args)
        {
            DisplayLogin displayLogin = new DisplayLogin();
            displayLogin.InitialDisplay();
            //NewArrayFromExcelcs newArrayFromExcelcs = new NewArrayFromExcelcs();
            //.MakeNewArrayFromExcel();
            //SearchTimeTable searchTimeTable = new SearchTimeTable();
            //searchTimeTable.SearchingTimeTable();
            //MenuOfInterestedSubject subject = new MenuOfInterestedSubject();
            //StudentData studentData = new StudentData();
            //studentData.InsertStudentData();
            //subject.ViewMenuOfInterestedSubject(studentData);
            //MenuOfRegisterLecture view = new MenuOfRegisterLecture();
            //view.ViewMenuOfRegisterLecture(studentData);
        }
    }
}
