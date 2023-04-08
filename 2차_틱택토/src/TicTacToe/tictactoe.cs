using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using System.Threading.Tasks;
using TicTacToe;
namespace Tictactoe
{

    //페이지 나눠서 클래스 분할,  컴퓨터랑 상대하기ㅇ, 점수 조회 메뉴o
    // 네이밍 신경쓰기, 입력값 예외처리o 

    //1. 무승부 추가, 누가 승리했는지 알려주는 멘트 추가
    //2, 컴퓨터랑 상대하기 코드수정
    //3. 점수조회 오류난 이유  -> 전역변수로 PUBLIC **STATIC** 써야함

    public class Tictactoe
    {
        public static void Main(String[] args) //메인함수
        {
            Menu menu = new Menu();
            menu.Display();
        }
    }

 }

   
