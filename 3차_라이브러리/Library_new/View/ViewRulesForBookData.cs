using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;
using Library.View;
using Library.Controller;
namespace Library.View
{
    internal class ViewRulesForBookData
    {
        public void RulesForBookData()
        {
            Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■");
            Console.WriteLine("  ID: 숫자 1개 이상" );
            Console.WriteLine("  Title: 영어, 한글, 숫자 1글자 이상 " );
            Console.WriteLine("  Author: 영어, 한글 1글자 이상" );
            Console.WriteLine("  Publisher: 영어, 한글, 숫자 1글자 이상" );
            Console.WriteLine("  price: 1 - 9999999 사이 자연수 "); 
            Console.WriteLine("  quantity: 1-999 사이의 자연수");
            Console.WriteLine("  publicationDate: 19xx 또는 20xx-xx-xx" );
            Console.WriteLine("  isbn: 정수 9개" );
            Console.WriteLine("  info: 영어, 한글, 숫자 1글자 이상" );
            Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■");
        }
    }
}
