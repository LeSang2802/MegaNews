using MegaNews.Models;
using System;
using System.Linq;

namespace MegaNews.Data
{
    public static class DataSeeder
    {
        public static void Seed(ApplicationDbContext context)
        {
            // Kiểm tra xem bảng tblArticle đã có dữ liệu hay chưa
            if (!context.tblArticle.Any())
            {
                context.tblArticle.AddRange(new[]
                {
                    new ArticleModel
                    {
                        Title = "Đề xuất nối dài công viên bờ sông Sài Gòn thêm một km",
                        Content = "Đoạn bờ sông Sài Gòn phía TP Thủ Đức từ cầu Ba Son đến Thủ Thiêm dài hơn một km" +
                        " được đề xuất cải tạo, nối với công viên hiện hữu nhằm tạo diện mạo mới cho khu vực.\r\n\r\nKiến nghị vừa được Trung tâm Phát triển hạ tầng kỹ thuật gửi UBND TP Thủ Đức." +
                        " Sau khi được cải tạo, dải đất này sẽ nối liền công viên bờ sông phía Khu đô thị Thủ Thiêm hiện hữu đã khai thác gần một năm nay." +
                        "\r\n\r\nTheo phương án đề xuất, ven sông Sài Gòn đoạn qua khu vực trên sẽ được chỉnh trang chiều ngang từ mép bờ vào trong rộng 100-120 m. " +
                        "Khi hoàn thành, nơi đây dự kiến có một số hạng mục chính như: nơi tổ chức sự kiện, khu công viên trung tâm, đường chạy bộ/xe đạp kết nối toàn khu ven sông, nhà điều hành, bãi đậu xe cùng các tiện ích khác." +
                        "Trong đó, khu vực tổ chức sự kiện đồng thời là nơi phục vụ các hoạt động ngoài trời cho người dân. Nơi này sẽ được bố trí thảm cỏ, cây xanh, hệ thống đèn chiếu sáng, trang trí... " +
                        "Khu công viên trung tâm sẽ được thiết kế thảm cỏ xanh, đường đi dạo, chạy bộ, đan xen các sân chơi đa năng... Riêng khu vực chạy bộ và xe đạp ở công viên sẽ tận dụng đường hiện hữu ven sông Sài Gòn." +
                        "\r\n\r\nViệc triển khai công viên được Trung tâm Phát triển hạ tầng kỹ thuật TP Thủ Đức dự kiến hoàn thành trước Tết Nguyên đán năm nay. Toàn bộ kinh phí từ nguồn xã hội hóa." +
                        "\r\n\r\nTheo đơn vị đề xuất, với vị trí đắc địa mặt tiền sông Sài Gòn, đối diện là bến Bạch Đằng, khu biệt thự Ba Son, công viên bờ sông phía Thủ Thiêm sẽ giúp cải tạo cảnh quan cả khu vực và góp phần phát triển kinh tế, du lịch.",
                        Summary = "Đoạn bờ sông Sài Gòn phía TP Thủ Đức từ cầu Ba Son đến Thủ Thiêm dài hơn một km được đề xuất cải tạo,...",
                        Category = "Sport",
                        ImageUrl = "~/image/ThoiSu1.jpg",
                        PublishedDate = DateTime.Now,
                        Author = "Gia Minh"
                    },
                    new ArticleModel
                    {
                        Title = "Lương ứng viên mảng Al cao hơn vị trí khác 10-50%",
                        Content = "Gần nửa trong số 500 doanh nghiệp được khảo sát sẵn sàng trả lương nhân sự mảng Al cao hơn vị trí khác 10-20%; 18% công ty trả cao hơn 20-50%." +
                        "\r\n\r\nBáo cáo Thực trạng nhân sự và tuyển dụng ngành công nghệ thông tin (IT) trong làn sóng Trí tuệ nhân tạo (Al) giai đoạn 2024-2025 do VietnamWorks" +
                        " inTech thuộc Navigos Group vừa công bố cung cấp thông tin tổng quan về tác động của Al đến thị trường lao động IT tại Việt Nam. Khảo sát thực hiện trên 1.500 ứng viên tại Hà Nội," +
                        " Đà Nẵng, TP HCM và một số tỉnh thành cùng 500 doanh nghiệp trong tháng 7-8.\r\n\r\nKết quả cho thấy lương của nhân sự mảng Al cao hơn hẳn so với các vị trí khác." +
                        " Cụ thể gần 44% doanh nghiệp trả hơn 10-20% và trên 18% đơn vị trả lương cao hơn 20-50%. Hơn một nửa doanh nghiệp ưu tiên tuyển nhân sự có kỹ năng dùng công cụ về AI " +
                        "bởi đã nhận ra tầm quan trọng của kỹ năng AI trong bối cảnh công nghệ phát triển.\r\n\r\nTình hình nhân sự IT tại Đà Nẵng ổn định nhất, trong khi TP HCM và Hà Nội có tỷ lệ cắt giảm cao," +
                        " lần lượt gần 17,7% và 18,6%. So với năm ngoái, doanh nghiệp giảm tỷ lệ cắt giảm IT nhưng lại tăng quy mô nhân sự trong năm nay. Phần lớn doanh nghiệp cho biết tăng khoảng 5-30% nhân sự lĩnh vực này. " +
                        "Doanh nghiệp tuyển dụng IT chủ yếu từ ngành gia công phát triển phần mềm, kinh doanh thương mại, sản xuất kỹ thuật, tư vấn công nghệ..." +
                        "\r\n\r\nNhìn chung, nhân sự công nghệ thông tin vẫn chịu ảnh hưởng hậu làn sóng cắt giảm lao động diện rộng sau đại dịch. 60% được khảo sát cho biết bị thôi việc trong năm trước vẫn chưa tìm được việc mới trong năm nay," +
                        " cao gấp rưỡi so với tỷ lệ tương tự ở nhóm nhân sự chủ động thôi việc. Trong khi đó, nhóm chủ động thường chuẩn bị kỹ lưỡng trước khi rời đi, có mối quan hệ nghề nghiệp nên ít đối mặt với thách thức hơn." +
                        " Tỷ lệ tìm được việc mới phù hợp và hài lòng ở nhóm này chiếm trên 24% và 17,5%.\r\n\r\nNhiều nhân sự IT vì thế sẵn sàng đảm nhận thêm khối lượng công việc hoặc đa nhiệm hơn để có được việc mới. \"Con số tăng 10% so với năm trước, cho thấy sự cạnh tranh trên thị trường việc làm ngày càng gay gắt\", báo cáo nhận định.",
                        Summary = "Gần nửa trong số 500 doanh nghiệp được khảo sát sẵn sàng trả lương nhân sự mảng Al cao hơn vị trí khác 10-20%; 18% công ty trả cao hơn 20-50%...",
                        Category = "News",
                        ImageUrl = "~/image/ThoiSu2.jpg",
                        PublishedDate = DateTime.Now,
                        Author = "Hồng Chiêu"
                    },
                    new ArticleModel
                    {
                        Title = "Messi ghi dấu khi Miami thắng trận đầu MLS Cup playoffs",
                        Content = "Lionel Messi kiến tạo để Jordi Alba ghi bàn ấn định chiến thắng 2-1 cho Inter Miami trước Atlata United ở trận ra quân MLS Cup playoffs. Messi bỏ lỡ nhiều cơ hội trong trận đấu mà Miami áp đảo về mọi mặt. Nhưng anh vẫn để lại dấu ấn với đường chuyền để Alba ghi siêu phẩm, ấn định chiến thắng cho đội chủ nhà Chase." +
                        "\r\n\r\nĐó là tình huống Messi lùi lại một nhịp sau khi thực hiện pha đá phạt góc để nhận đường chuyền từ đồng đội. Anh chuyền về tuyến hai cho Alba tung cú sút từ khoảng cách 25 m về góc gần, vượt khỏi tầm với của thủ thành Brad Guzan.\r\n\r\nMessi giơ tay, chia vui một cách cuồng nhiệt với người đồng đội từ thời còn ở Barca." +
                        " Dù không ghi bàn, anh được đồng đội công kênh trên vai. Pháo hoa cũng được bắn lên để hưởng ứng không khí. Đây là lần đầu trong lịch sử Inter Miami chơi một trận sân nhà trong khuôn khổ MLS Cup playoffs - giải đấu danh giá nhất trong năm của bóng đá Mỹ. \r\n\r\n Miami nhập cuộc với tâm thế của đội cửa trên. " +
                        "Họ tung ra tới 22 pha dứt điểm, trong đó có 12 lần trúng đích, trong khi Atlanta United chỉ dứt điểm tám lần với hai lần hướng khung thành. Đội chủ nhà thành công trong việc triển khai lối chơi kiểm soát bóng như thường lệ, với 66% thời lượng. Họ thậm chí mở tỷ số ngay phút thứ 2, nhờ công Luis Suarez." +
                        "\r\n\r\nAlba cũng góp công trong bàn này với pha đi bóng ở cánh trái trước khi chuyền để Diego Gomez kiến tạo. Pha dứt điểm một chạm của Suarez đưa bóng đi chìm, qua giữa hai chân của Guzan.Với tâm lý hưng phấn, Miami tiếp tục dồn ép và Messi đáng ra đã nhân đôi cách biệt nếu cú sút một chạm từ ngoài cấm địa của anh không bị Guzan cản phá." +
                        "\r\n\r\nGuzan sau đó tiếp tục từ chối cú sút về góc cao của Messi, trước khi trung vệ David Martinez khiến khung thành đội khách rung chuyển với cú đánh đầu dội cột dọc. Bản thân Messi sau đó cũng có một lần dứt điểm trúng khung gỗ ở cự ly gần.\r\n\r\n",
                        Summary = "Lionel Messi kiến tạo để Jordi Alba ghi bàn ấn định chiến thắng 2-1 cho Inter Miami trước Atlata United ở trận ra quân MLS Cup playoffs....",
                        Category = "Sport",
                        ImageUrl = "~/image/TheThao1.png",
                        PublishedDate = DateTime.Now,
                        Author = "Quang Huy"
                    },
                    // Thêm các bài viết khác tại đây...
                });

                context.SaveChanges(); // Lưu dữ liệu vào cơ sở dữ liệu
            }
        }
    }
}
