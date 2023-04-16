using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Library.Model;
using Library.View;
using Library.Controller;

namespace Library.Controller
{
    
    internal class CheckInputIsEnter
    {
        private BookData bookData;
        private UserData userData;
        public CheckInputIsEnter(BookData bookData, UserData userData)
        {
            this.bookData = bookData;
            this.userData = userData;
        }
        public KeyValuePair<string, int> SaveIDIfNotEnter(string randomExpression, int entercase)

        {
            DetermineWithRegularExpression determineWithRegularExpression = new DetermineWithRegularExpression(bookData, userData);
            while (true)
            {
                ConsoleKeyInfo IDinput = Console.ReadKey();
                if (IDinput.Key == ConsoleKey.Enter) //입력한 값이 엔터면
                {
                    break;
                }
                else //입력한 값이 엔터가 아니면 
                {
                    entercase++; //엔터 하나만 치는거면 entercase가 0이고 다른 문자 입력되면 entercase 1이상
                    randomExpression += IDinput.KeyChar;
                }
            }
            if (entercase >= 1)
            {
                int TypeCheck = 0;
                entercase = 0;
                determineWithRegularExpression.JudgeID(randomExpression, TypeCheck);
            }

            return new KeyValuePair<string, int>(randomExpression, entercase);
        }
        //ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ
        public KeyValuePair<string, int> SaveTitleIfNotEnter(string randomExpression, int entercase)

        {
            DetermineWithRegularExpression determineWithRegularExpression = new DetermineWithRegularExpression(bookData, userData);
            while (true)
            {
                ConsoleKeyInfo Titleinput = Console.ReadKey();
                if (Titleinput.Key == ConsoleKey.Enter) //입력한 값이 엔터면
                {
                    break;
                }
                else //입력한 값이 엔터가 아니면 
                {
                    entercase++; //엔터 하나만 치는거면 entercase가 0이고 다른 문자 입력되면 entercase 1이상
                    randomExpression += Titleinput.KeyChar;
                }
            }
            if (entercase >= 1)
            {
                int TypeCheck = 0; entercase = 0;
                determineWithRegularExpression.JudgeBookName(randomExpression, TypeCheck);
            }

            return new KeyValuePair<string, int>(randomExpression, entercase);
        }
        //ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ
        public KeyValuePair<string, int> SaveAuthorIfNotEnter(string randomExpression, int entercase)

        {
            DetermineWithRegularExpression determineWithRegularExpression = new DetermineWithRegularExpression(bookData, userData);
            while (true)
            {
                ConsoleKeyInfo Authorinput = Console.ReadKey();
                if (Authorinput.Key == ConsoleKey.Enter) //입력한 값이 엔터면
                {
                    break;
                }
                else //입력한 값이 엔터가 아니면 
                {
                    entercase++; //엔터 하나만 치는거면 entercase가 0이고 다른 문자 입력되면 entercase 1이상
                    randomExpression += Authorinput.KeyChar;
                }
            }
            if (entercase >= 1)
            {
                int TypeCheck = 0; entercase = 0;
                determineWithRegularExpression.Judgeauthor(randomExpression, TypeCheck);
            }

            return new KeyValuePair<string, int>(randomExpression, entercase);
        }
        //ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ
        public KeyValuePair<string, int> SavePublisherIfNotEnter(string randomExpression, int entercase)

        {
            DetermineWithRegularExpression determineWithRegularExpression = new DetermineWithRegularExpression(bookData, userData);
            while (true)
            {
                ConsoleKeyInfo Publisherinput = Console.ReadKey();
                if (Publisherinput.Key == ConsoleKey.Enter) //입력한 값이 엔터면
                {
                    break;
                }
                else //입력한 값이 엔터가 아니면 
                {
                    entercase++; //엔터 하나만 치는거면 entercase가 0이고 다른 문자 입력되면 entercase 1이상
                    randomExpression += Publisherinput.KeyChar;
                }
            }
            if (entercase >= 1)
            {
                int TypeCheck = 0; entercase = 0;
                determineWithRegularExpression.JudgePublisher(randomExpression, TypeCheck);
            }

            return new KeyValuePair<string, int>(randomExpression, entercase);
        }
        //ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ
        public KeyValuePair<string, int> SavePriceIfNotEnter(string randomExpression, int entercase)

        {
            DetermineWithRegularExpression determineWithRegularExpression = new DetermineWithRegularExpression(bookData, userData);
            while (true)
            {
                ConsoleKeyInfo Priceinput = Console.ReadKey();
                if (Priceinput.Key == ConsoleKey.Enter) //입력한 값이 엔터면
                {
                    break;
                }
                else //입력한 값이 엔터가 아니면 
                {
                    entercase++; //엔터 하나만 치는거면 entercase가 0이고 다른 문자 입력되면 entercase 1이상
                    randomExpression += Priceinput.KeyChar;
                }
            }
            if (entercase >= 1)
            {
                int TypeCheck = 0; entercase = 0;
                determineWithRegularExpression.Judgeprice(randomExpression, TypeCheck);
            }

            return new KeyValuePair<string, int>(randomExpression, entercase);
        }
        //ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ
        public KeyValuePair<string, int> SaveQuantityIfNotEnter(string randomExpression, int entercase)

        {
            DetermineWithRegularExpression determineWithRegularExpression = new DetermineWithRegularExpression(bookData, userData);
            while (true)
            {
                ConsoleKeyInfo Quantityinput = Console.ReadKey();
                if (Quantityinput.Key == ConsoleKey.Enter) //입력한 값이 엔터면
                {
                    break;
                }
                else //입력한 값이 엔터가 아니면 
                {
                    entercase++; //엔터 하나만 치는거면 entercase가 0이고 다른 문자 입력되면 entercase 1이상
                    randomExpression += Quantityinput.KeyChar;
                }
            }
            if (entercase >= 1)
            {
                int TypeCheck = 0; entercase = 0;
                determineWithRegularExpression.Judgequantity(randomExpression, TypeCheck);
            }

            return new KeyValuePair<string, int>(randomExpression, entercase);
        }
        //ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ
        public KeyValuePair<string, int> SavePublicationIfNotEnter(string randomExpression, int entercase)

        {
            DetermineWithRegularExpression determineWithRegularExpression = new DetermineWithRegularExpression(bookData, userData);
            while (true)
            {
                ConsoleKeyInfo Publicationinput = Console.ReadKey();
                if (Publicationinput.Key == ConsoleKey.Enter) //입력한 값이 엔터면
                {
                    break;
                }
                else //입력한 값이 엔터가 아니면 
                {
                    entercase++; //엔터 하나만 치는거면 entercase가 0이고 다른 문자 입력되면 entercase 1이상
                    randomExpression += Publicationinput.KeyChar;
                }
            }
            if (entercase >= 1)
            {
                int TypeCheck = 0; entercase = 0;
                determineWithRegularExpression.JudgepublicationDate(randomExpression, TypeCheck);
            }

            return new KeyValuePair<string, int>(randomExpression, entercase);
        }
        //ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ
        public KeyValuePair<string, int> SaveIsbnIfNotEnter(string randomExpression, int entercase)

        {
            DetermineWithRegularExpression determineWithRegularExpression = new DetermineWithRegularExpression(bookData, userData);
            while (true)
            {
                ConsoleKeyInfo Isbninput = Console.ReadKey();
                if (Isbninput.Key == ConsoleKey.Enter) //입력한 값이 엔터면
                {
                    break;
                }
                else //입력한 값이 엔터가 아니면 
                {
                    entercase++; //엔터 하나만 치는거면 entercase가 0이고 다른 문자 입력되면 entercase 1이상
                    randomExpression += Isbninput.KeyChar;
                }
            }
            if (entercase >= 1)
            {
                int TypeCheck = 0; entercase = 0;
                determineWithRegularExpression.Judgeisbn(randomExpression, TypeCheck);
            }

            return new KeyValuePair<string, int>(randomExpression, entercase);
        }
        //ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ
        public KeyValuePair<string, int> SaveInfoIfNotEnter(string randomExpression, int entercase)

        {
            DetermineWithRegularExpression determineWithRegularExpression = new DetermineWithRegularExpression(bookData, userData);
            while (true)
            {
                ConsoleKeyInfo Infoinput = Console.ReadKey();
                if (Infoinput.Key == ConsoleKey.Enter) //입력한 값이 엔터면
                {
                    break;
                }
                else //입력한 값이 엔터가 아니면 
                {
                    entercase++; //엔터 하나만 치는거면 entercase가 0이고 다른 문자 입력되면 entercase 1이상
                    randomExpression += Infoinput.KeyChar;
                }
            }
            if (entercase >= 1)
            {
                int TypeCheck = 0; entercase = 0;
                determineWithRegularExpression.Judgeinfo(randomExpression, TypeCheck);
            }

            return new KeyValuePair<string, int>(randomExpression, entercase);
        }
    }
}


