# Booking slot overlap check

У `BookingRepository.CreateIfAvailableAsync()` відкривається транзакція з рівнем ізоляції `Serializable`.

Усередині транзакції виконується перевірка вільних слотів:

```csharp
b.ResourceId == booking.ResourceId &&
b.Status != Status.Cancelled &&
b.StartTime < booking.EndTime &&
b.EndTime > booking.StartTime
```

Якщо перетин знайдено то транзакція відкочується а метод повертає `null`.
У `BookingService.AddAsync()` це перетворюється на `BookingConflictException`.
У `BookingController` ця помилка повертається як HTTP `409 Conflict`.

Чому я обрав саме такий підхід?:

- перевірка виконується на рівні БД, а не лише в пам’яті;
- `Serializable` зменшує ризик race condition, коли два паралельні запити одночасно бачать слот як вільний;
- `unique constraint` тут не підходить, бо задача — не рівність значень, а перетин часових інтервалів.

Якщо слот уже зайнятий, API повертає:

```json
{
  "message": "Resource is already booked for this time.",
  "code": "Booking Conflict"
}
```
 або

```json
{
  "message": "Start time must be earlier than end time.",
  "code": "Booking Conflict"
}
```
якщо час кінця < часу початку
