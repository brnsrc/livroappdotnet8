namespace  Northwind.EntityModels;
public record class Cart(
    Customer customer,
    List<LineItem> Items
);
