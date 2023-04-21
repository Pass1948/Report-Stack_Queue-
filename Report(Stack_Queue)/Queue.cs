using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report_Stack_Queue_
{
    // Queue는 선입선출의 특징을 가지고 있는 자료구조로 데이터는 입력 순서대로 쌓이고 연속적이지만
    // 호출, 출력될때 먼저들어간 순서대로 처리를 할수있는 구조로 이뤄저야 한다
    // 기존에 앞에 데이터를 제거하면 뒤에 데이터들이 전부 한칸씩 옮기는 방식을 썼던 선형구조를 바꿔서
    // 선단, 후단이 옮겨가는 방식으로 쓰고 구조를 기존 선형에서 환형(원형)으로 바꿔서 순환하는 구조로
    // 설계하여 앞에 데이터 선단의 데이터가 호출되어 제거되면 그다음으로 선단이 이동하고
    // 추가되면 후단에 추가되어 이동하는 형태로 되며 다 차있는 경우 배열의 허용량을 늘려주는 식으로
    // 진행하여 List과 LinkList의 합친개념에 순환형구조를 쓴 신모델로 생각되어진다

    public class Queue<T>
    {
        private const int DefaultCapacity = 4;      // 순환형 구조의 허용량을 설정해준다
        private T[] array;                          // 배열은 일반형으로 설정해준다
        private int head;                           // 선단을 head로 두고
        private int tail;                           // 후단을 tail로 둔다
        
        public int Count                            // 배열의 크기를 나타내주기 위해 Count를 설정한다
        {
            get
            {
                if (head <= tail)                   // head가 tail 보단 적단 이야기는 크기가 5라면 head는 0 tail은 4에 있단 이야기로
                                                    // 곧 tail -head는 5-0로 배열의 현재 크기를 알려준다
                    return tail - head;
                else
                    return tail - (head + array.Length);   // tail이 head의 뒤에 있는 경우 배열의 크기가 허용량에 꽉찼을 경우일수 있기애
                                                           // tail(-1) -  (haed(1) + 5의 허용량)
                                                           // 해주게 되면 현재 배열의 크기가 나오게 된다
            }
        }

        public Queue()
        {
            array = new T[DefaultCapacity + 1]; // 환형에서 추가가 계속일어나 후단이 선단과 겹치는 지점에 이르게 될수도 있다
                                                // 이경우를 방지하기 위해 빈칸 1칸을 만들어서 
            head = 0;                           // head는 시작점으로 초기화 해준다
            tail = 0;                           // 처음엔 head와 같은 시작점이지만 이후 추가될때 tail이 이동하기애 처음엔 겹치는 0으로 해준다(0부터 데이터가 들어가기애)

        }
        public void Enqueue(T item)             // 추가 함수를 구현해준다
        {
            if (IsFull())                       // 별도로 배열의 크기가 배열의 허용량에 full이 됬을 경우로 조건을 걸어준다
            {
                Grow();                         // List의 더 큰배열을 만들어 주듯 Queue또한 더큰 환형배열을 키워준다
            }

            array[tail] = item;                 // 추가되는 함수가 tail에 들어가고
            MoveNext(ref tail);                 // tail을 옮겨준다 이때 위치가 움직여서 주소값도 함께 바꿔야 하기애 ref를 써준다
        }

        public T Dequeue()                      // 0부터 배열허용량 까지 순서대로 데이터를 호출하는 함수
        {
            if (IsEmpty())                      // 배열에 데이터가 없을경우 에러가 발생하기애 예외처리를 진행해 준다
                throw new InvalidOperationException();

            T result = array[head];             // 시작점인 head부터 호출되어야 해서 호출값을 head로 지정
            MoveNext(ref head);                 // 추가와 마찬가지로 tail까지 순서대로 움직여야해서 head에도 ref를 붙여준다
            return result;
        }

        public T Peek()                         // 현재 최전방 데이터를 호출하는 함수
        {
            if (IsEmpty())                      // 위에 순서대로 호출함수와 마찬가지로 비어있는 상태에 대한 예외처리를 진행한다
                throw new InvalidOperationException();
            return array[head];                 // 최전방데이터는 현재 head에 존재하기애 head의 값을 반환한다
        }

        public void MoveNext(ref int index)     // head와 tail의 이동함수
        {
            index = (index == array.Length - 1) ? 0 : index + 1;  
            // 끝에 있을경우(허용량(5)에 -1 = 배열크기) 처음지점(0)으로 가게 설계
            // 그게 아니라면 옆으로 한칸이동)
        }

        private bool IsEmpty()                  // 비어있는 상황
        {
            return head == tail;                // 처음 초기값이 둘다 0이어서 둘다 겹친값이 나올때 데이터가 없다고 가정한다
        }

        private bool IsFull()                   // 배열허용량에 데이터가 꽉찼을 경우
        {
            if (head > tail)                    // 선형에서 보면 t - h인 상황으로 순환구조에서는 t이 한바퀴를 돌은 상황이다
                return head == tail + 1;        // 
            else
                return Count == array.Length - 1 && tail == array.Length - 1;   // tail이 배열 마지막에 있는경우 바로 위해 코드를 인식하지 못하는 상황을 보강하기위해 설계함   
        }

        private void Grow()
        {
            int newCapacity = array.Length * 2;         // 더큰 배열을 만들기
            T[] newArray = new T[newCapacity + 1];      // tail 자리 만들기

            if (head < tail)                        // head가 tail의 앞에 있을땐 그냥 복사가능
            {
                Array.Copy(array, head, newArray, 0, tail);
            }
            else                                   // tail이 head보다 더욱 앞에 있어서 큰배열에 빈자리가 생길경우
            // 앞에 데이터(head)을 복사해서 맨 처음에 붙여넣고 뒤에 데이터(tail) 복사해서 head다음 데이터에 붙여넣어서 연속적인 배열로 만들어줌
            {
                Array.Copy(array, head, newArray, 0, array.Length - head);  // 헤드 부터 끝까지 복사해서 맨처음으로 불여넣고
                Array.Copy(array, 0, newArray, array.Length - head, tail);  // tail부터 0번까지 복사해서 head다음에 붙여넣기
                head = 0;
                tail = Count;
            }
            array = newArray;
        }
    }
}
