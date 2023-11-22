## Controller
- Là một lớp kế thừa lớp Controller : Microsoft.AspNetCore.Mvc.Controller
- Action trong controller là 1 phương thức public(không được static)
- Action trả về bất cứ kiểu dữ liệu nào, thường là IactionResult
- Các dịch vụ inject vào controller qua hàm tạo 

## View
- là file .cshtml 
- View cho Action lưu tại : /View/ControllerName/ActionName.cshtml
- Thêm thư mục lư trữ View:(kiểu ngoài mặc định là /View/.../..) thì có thể thiết lập thêm 
'''
// {0} là tên Action
// {1} tên Controller
// {2} tên Area
options.ViewLocationFormats.Add("/MyView.{1}/{0}"+RazorViewEngine.ViewExtension);
'''
## Truyền dữ liệu sang View 
- Model 
- ViewData
- ViewBag
- TeamData

