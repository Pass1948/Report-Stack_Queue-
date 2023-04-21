using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report_Stack_Queue_
{
    // 선입후출의 특징을 가진 Stack은 순차적으로 쌓이고 연속적으로 데이터가
    // 이어저 있어서 이와 비슷한 배열구조를 가진 자료구조의 기능을 활용해서
    // Stack의 기능을 구현해준다 본래있던 클래스를 인터페이스처럼
    // 활용해서 새로운 클래스에서 구현하는것을 Adapter패턴이라고 한다
    public class Stack2<T>                    //배열형 자료구조인 List의 기능을 활용해서 Stack을 구현한다
    {
        private List<T> container;                    // 일반형 List를 불러오고  
        public int Count { get {return container.Count; } } 
        // 현재 배열의 크기를 호출하고 싶다면
        // List에서는 Count를 사용하기애 List의 Count도 불러와서 활용한다
        public Stack2()                                // 변수에 초기화 해준다
        {
            this.container = new List<T>();

        }
        public void Push(T item)                       // List에서 추가 기능Add를 Stack에서 Push로 표현함
                                                       // 이 경우 수직상자형태로 설명하면 데이터가 먼저 들어온게
                                                       // 제일 아래 쌓이고 그담 위로 점점 쌓여지는 형태가 된다
        {
            container.Add(item);
        }

        public T Pop()                                  // Stack에 쌓여진 데이터들을 제일 최상단 데이터부터 호출하는 함수로
                                                        // 최상단에서 부터 맨 아래까지 반복문을 통해 출력할수있다
        {
            T item = container[container.Count - 1];    // Count는 현재 배열의 크기를 뜻하며 만약 5면 0,1,2,3,4이기애 4부터 호출되어야 해서 5에서 -1로 4부터 나오도록 설정해준다
            container.RemoveAt(container.Count - 1);    // 변수 container에 4의 값이 남아있기애 다음 3의 값을 호출해주기 위해 container의 값은 없애는 List의 기능 RemoveAt을 사용해서 제거해준다
            return item;
        }

        public T Peek()                                 // 제일 최상단의 데이터를 호출하는 함수
        {
            return container[container.Count - 1];      // 위에 pop함수에서 썼던 연산으로 크기에 -1해서 최상단의 데이터를 호출한다
        }

    }
}
