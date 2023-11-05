# KaBooM
Project of Lam 
Mô tả trò chơi
Tên : Pirate Hunter
THỂ LOẠI: 2D platformers
VỀ TRÒ CHƠI NÀY: 
Chiến đấu, khám phá trong thế giới Pirate Hunter.
Nhập vai vào thế giới nguy hiểm nhưng nhiều kho báu, chiến đấu và lấy lại kho báu từ các sinh vật kỳ lạ.
TÍNH NĂNG TRONG TRÒ CHƠI:
+ Nhân vật chính: Thuyền Trưởng (nhập vai để tìm lại kho báu bị cướp).
+ Gameplay:
  - Điều khiển nhân vật chính tìm lại kho báu bị cướp.
  - Combat kiểu 2D platform kiếm thưởng và mua item.
  - Sử dụng khả năng ném kiếm để kích hoạt cơ quan và combat.
+ Kĩ năng nhân vật:
  - Di chuyển kiểu 2D platform, nhảy đúp.
  - Chém liên tục có combo gồm 3 đòn.
  - Ném kiếm (khi ném xong phải nhặt lại để ra đòn và ném tiếp).
  - Thanh slider để chỉnh lực đáp kiếm.
  - Hồi máu (dùng bình máu).
+ Kẻ địch:
   Crabby/Piggy: - 4 phase chính ( idle, run, charge, Attack)
                 - trigger vị trí của player => chạy đến chỗ player => (if đủ điều kiện) Vận sức và ra đòn.
                 - Tạo ra phần thưởng khi chết.
                 - Có lượng HP nhất định.

   Cannon: - Bắn pháo khi người chơi lại gần (sát thương lớn).
           - Có lượng HP nhất định.

   Seashell: - Đứng yên bắn ngọc trai khi người chơi ở xa.
             - Chuyển sang cắn gây sát thương gần khi người chơi lại gần.
             - Thời gian giữa các lần ra đòn và bắn được sắp xếp hợp lý.
             - Có lượng HP nhất định.
+ Hiệu ứng môi trường và nhân vật:
  - Slowmotion khi bị trúng đòn.
  - Các hiệu ứng ra đòn, chạy, nhảy,...
  - glowing effect (mặt trời, cửa sổ, nến,...).
  - particle effrect (hiệu ứng gió).
+ Item:
  - Coins: rơi ra khi đánh quái và thùng chứa item.
  - Bình máu: hồi máu (có thể mua trong cửa hàng).
  - Thùng (chứa tiền hoặc các vật phẩm hữu ích).
+ Game Manager:
  - Lưu dữ liệu sử dụng Json.
  - Multiple resolution/Screen (giữ nguyên chiều dài cho mọi thiết bị).
  - Fps: 55-60.
  - Build cho android và ios.
