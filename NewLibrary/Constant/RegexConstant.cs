using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLibrary.Constant
{
    internal class RegexConstant
    { //정규식 constant 처리

        public const string koreanCharRegex = @"^[가-힣]$"; //한글 한 글자 

        //유저 정규식
        public const string userIdRegex = @"^[a-zA-Z0-9]{5,12}$"; //영어 + 숫자 4-16자리
        public const string userPwRegex = @"^[\p{L}\p{N}]{6,12}$"; //영어 _ 숫자 6-12
        public const string userNameRegex = @"^[가-힣]{2,4}$"; //2-4글자사이정규식
        public const string userAgeRegex = @"^(1[0-9]{2}|[1-9][0-9]|[1-9])$"; //0에서 200사이 정규식
        public const string userPhoneNumberRegex= @"^\d{3}-\d{3,4}-\d{4}$";//
        public const string userAddressRegex= @"(([가-힣A-Za-z·\d~\-\.]{2,}(로|길).[\d]+)|([가-힣A-Za-z·\d~\-\.]+(읍|동)\s)[\d]+)";

        //책 정규식
        public const string onlyNumberRegex = @"^[0-9]+"; //책 아이디
        public const string englishKoreanNumberRegex = @"^[\p{L}\p{N}]+$"; //영어,한글,숫자 1글자 이상, 책이름,출판사, info
        public const string englishKoreanRegex = @"^[\p{L}]+$";//영어, 한글 1글자 이상, 작가명
        public const string priceRegex = @"^[1-9][0-9]{0,6}$";//1-9999999 사이 자연수
        public const string quantityRegex = @"^[1-9][0-9]{0,2}$";//1-999 사이 자연수
        public const string publicationDateRegex = @"^(19|20)\d{2}-(0[1-9]|1[012])-(0[1-9]|[12][0-9]|3[0-1])"; //출판일자
        public const string isbnRegex = @"^\d{9}$"; //isbn, 정수 9개
    }
}
