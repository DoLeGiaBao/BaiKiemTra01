# Phần I - Lý thuyết & Câu hỏi ngắn

## Câu 1: Phân biệt Value Types và Reference Types trong C#

**Value Types (Kiểu giá trị):**
- Lưu trực tiếp giá trị của biến.
- Khi gán một biến cho biến khác, giá trị được sao chép sang biến mới.
- Thường được lưu trên Stack khi là biến cục bộ.
- Các kiểu phổ biến: `int`, `double`, `bool`, `struct`, `enum`.

**Reference Types (Kiểu tham chiếu):**
- Biến lưu tham chiếu đến đối tượng được lưu trên Heap.
- Khi gán một biến cho biến khác, hai biến có thể cùng tham chiếu đến một đối tượng.
- Các kiểu phổ biến: `class`, `object`, `string`, `array`.



## Câu 2: Init-only Properties (`init`) khác gì so với thuộc tính có `set`?

`init` cho phép thuộc tính chỉ được gán giá trị trong quá trình khởi tạo đối tượng và không thể thay đổi sau khi đối tượng đã được khởi tạo.

Trong khi đó, thuộc tính sử dụng `set` có thể được gán và thay đổi giá trị bất kỳ lúc nào sau khi đối tượng được tạo.

**Trường hợp sử dụng:** `init` phù hợp với các thuộc tính cần được thiết lập một lần khi khởi tạo đối tượng và không muốn bị thay đổi sau đó, giúp đảm bảo tính ổn định và an toàn của dữ liệu.



## Câu 3: Phân biệt `virtual` và `override` trong tính Đa hình

`virtual` được khai báo trong lớp cha để cho phép phương thức được lớp con ghi đè.

`override` được khai báo trong lớp con để ghi đè và cung cấp cách triển khai mới cho phương thức `virtual` của lớp cha.

Sự kết hợp giữa `virtual` và `override` cho phép chương trình thực hiện tính Đa hình (Polymorphism), trong đó phương thức được gọi phụ thuộc vào kiểu thực tế của đối tượng.



## Câu 4: Tại sao thành phần `static` trong Class không thể truy xuất thông qua Object Instance?

Thành phần `static` thuộc về Class chứ không thuộc về từng Object Instance.

Nó được tạo và quản lý ở cấp độ lớp, được dùng chung cho tất cả các đối tượng thuộc lớp đó.

Vì vậy, thành phần `static` phải được truy xuất thông qua tên Class thay vì thông qua Object Instance được tạo bằng toán tử `new`.

Điều này đảm bảo thành phần `static` chỉ có một bản dùng chung cho toàn bộ Class.