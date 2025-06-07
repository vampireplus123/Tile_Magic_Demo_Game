
## Hướng dẫn sử dụng

1. **Mở project bằng Unity** (phiên bản 2021.3.x hoặc mới hơn được khuyến nghị).
2. **Chuẩn bị scene chính**: Các prefabs đã có sẵn trong thư mục prefabs
    - Thêm các `SpawnPoint` để tile có thể xuất hiện.
    - Kéo `TileManager` và gán `tilePrefab`, cấu hình số lượng pool.
    - Chuẩn bị UI canvas với các thành phần `scoreText`, `feedbackText`, `gameOverPanel`, `startButton`.
3. **Chạy game**:  
    - Nhấn nút Start để bắt đầu.
    - Nhấn vào các tile rơi xuống để ghi điểm.
4. **Điểm số** được tính theo công thức: `BasePoint * Multiplier`, với multiplier phụ thuộc vào thời gian phản ứng.
5. **Feedback UI** hiển thị trạng thái "Perfect", "Good!", hoặc "Nice!" dựa trên điểm số nhận được.

## Các class chính và chức năng

- **ScoreManager**: Quản lý điểm số, nhận điểm từ tile, tính multiplier dựa trên thời gian phản ứng.
- **TileManager**: Quản lý pool tile, cấp phát và thu hồi tile.
- **UIManager**: Cập nhật UI điểm số, hiển thị phản hồi và màn hình kết thúc.
- **TileBase**: Lớp cơ sở cho tile, xử lý các hiệu ứng chung như rung lắc, đổi sprite.
- **ShortTile** và **LongTile**: Các loại tile cụ thể với điểm và hành vi riêng biệt.
- **ITilePoint**: Interface định nghĩa phương thức trả điểm cho tile.

## Mở rộng và nâng cấp
- Hoàn thiện tính năng tính điểm cho `LongTile`.
- Thêm nhiều loại tile với hiệu ứng và điểm số khác nhau.
- Sử dụng event/callback để quản lý tương tác tile linh hoạt hơn.
- Tối ưu hiệu suất pool tile và quản lý memory.
- Thêm âm thanh và hiệu ứng hình ảnh để tăng trải nghiệm người chơi.

## Yêu cầu
- Unity 2021.3.x
- TextMeshPro (đã tích hợp sẵn trong Unity).

---

**Chúc bạn chơi game vui vẻ!** 🎮

