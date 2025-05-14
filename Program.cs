using System.Collections.Specialized;

namespace ConsoleApp23;
class Category
{
    public int Id { get; set; }
    public string Name {get;set;}

    public Category(int id, string name){
        Id = id;    
        Name = name;
    }
}


class Employee{
    public int Id { get; set;}
    public string Name { get; set;}

    public decimal Salary {get;set;}

    public int sectionId {get;set;}

    public Employee(int id, string name, decimal salary, int sectionId){
        this.Id = id;
        this.Name = name;
        this.Salary = salary;
        this.sectionId = sectionId;
    }
}


enum OrderStatus {Pending, OnTheWay, Deliveried, PaymentRejected} ;
class Order{
    public int Id{get;set;}
    public int userId{get;set;}

    public OrderStatus Status {get;set;}

    public Order(int id, int userId, OrderStatus status){
        this.Id = id;
        this.userId = userId;
        this.Status = status;
    }


}


class OrderDetails
{
    public int Id { get; set; }
    public int orderId { get; set; }
    public int productId { get; set; }

    public int count {get;set;}

    public OrderDetails(int id, int orderId, int productId, int count){
        this.Id = id;
        this.orderId = orderId;
        this.productId = productId;
        this.count = count;
    }
}


class Product
{
    public int Id { get; set;}
    public string Name {get;set;}
    public double Price {get;set;}

    public int categoryId {get;set;}

    public Product(int id, string name, double price, int categoryId){
        this.Id = id;
        this.Name = name;
        this.Price = price;
        this.categoryId = categoryId;
    }
    public override string ToString() {
        return $"{{Id: {Id}, Name:{Name}, Price:{Price} USD, categorry: {categoryId}}}\n";
    }
}
class Marketing{
    public int Id {get;set;}
    public string Name {get;set;}

    public Marketing(int id,string name){
        Id = id;
        Name = name;
    }
}
class User{
    public int Id{get;set;}
    public string Name{get;set;}

    public User(int id,string name){
        this.Id = id;
        this.Name = name;
    }
}

class Program
{
    public static void Main(string[] args)
    {
        var categories = new List<Category>
        {
            new Category(1, "Books"),
            new Category(2, "Electronics"),
            new Category(3, "Clothing"),
            new Category(4, "Home & Kitchen"),
            new Category(5, "Toys")
        };

        var products = new List<Product>
        {
            new Product(1, "C# Programming Book", 29.99, 1),
            new Product(2, "JavaScript for Beginners", 24.99, 1),
            new Product(3, "Blender", 59.99, 4),
            new Product(4, "Smartphone", 499.99, 2),
            new Product(5, "Laptop", 999.99, 2),
            new Product(6, "Tablet", 199.99, 2),
            new Product(7, "T-Shirt", 14.99, 3),
            new Product(8, "Jeans", 39.99, 3),
            new Product(9, "Jacket", 89.99, 3),
            new Product(10, "Lego Set", 89.99, 5),
            new Product(11, "Action Figure", 19.99, 5),
            new Product(12, "Cooking Pot", 34.99, 4),
            new Product(13, "Electric Kettle", 24.99, 4),
            new Product(14, "Data Structures Book", 34.99, 1),
            new Product(15, "Monitor", 149.99, 2),
            new Product(16, "Keyboard", 49.99, 2),
            new Product(17, "Microwave", 99.99, 4)
        };

        var sections = new List<Marketing>
        {
            new Marketing(1, "Holiday Sale"),
            new Marketing(2, "Buy One Get One"),
            new Marketing(3, "Summer Clearance"),
            new Marketing(4, "New Arrivals Launch"),
            new Marketing(5, "Back to School Promo")
        };

        var employees = new List<Employee>
        {
            new Employee(1, "Alice Johnson", 55000m, 1),
            new Employee(2, "Bob Smith", 62000m, 2),
            new Employee(3, "Catherine Lee", 58000m, 1),
            new Employee(4, "David Brown", 70000m, 3),
            new Employee(5, "Eva Green", 64000m, 2),
            new Employee(6, "Frank Moore", 75000m, 4),
            new Employee(7, "Grace Hall", 53000m, 1),
            new Employee(8, "Henry Scott", 60000m, 3),
            new Employee(9, "Isabella Adams", 72000m, 4),
            new Employee(10, "Jack Turner", 50000m, 2)
        };

        var users = new List<User>
        {
            new User(1, "Anna"),
            new User(2, "Brian"),
            new User(3, "Carla"),
            new User(4, "Derek"),
            new User(5, "Emily")
        };
        var orders = new List<Order>
        {
            new Order(1, 1, OrderStatus.Pending),
            new Order(2, 1, OrderStatus.Deliveried),
            new Order(3, 2, OrderStatus.OnTheWay),
            new Order(4, 3, OrderStatus.Deliveried),
            new Order(5, 3, OrderStatus.Pending),
            new Order(6, 3, OrderStatus.OnTheWay),
            new Order(7, 4, OrderStatus.PaymentRejected),
            new Order(8, 5, OrderStatus.Deliveried)
        };

        var orderDetails = new List<OrderDetails>
        {
            new OrderDetails(1, 1, 1, 1),    // User 1
            new OrderDetails(2, 1, 2, 2),    // User 1
            new OrderDetails(3, 2, 3, 1),    // User 1
            new OrderDetails(4, 3, 4, 1),    // User 2
            new OrderDetails(5, 4, 5, 1),    // User 3
            new OrderDetails(6, 5, 6, 2),    // User 3
            new OrderDetails(7, 5, 7, 1),    // User 3
            new OrderDetails(8, 6, 8, 3),    // User 3
            new OrderDetails(9, 7, 9, 1),    // User 4
            new OrderDetails(10, 8, 10, 1),  // User 5
            new OrderDetails(11, 2, 11, 2),  // User 1
            new OrderDetails(12, 5, 12, 1),  // User 3
            new OrderDetails(13, 6, 13, 1),  // User 3
            new OrderDetails(14, 6, 14, 2),  // User 3
            new OrderDetails(15, 6, 15, 1)   // User 3
        };


        var UserWithOrders = (
            from user in users
            join order in orders on user.Id equals order.userId
            select user.Name
        );
        foreach (var Name in UserWithOrders.Distinct())
        {
            Console.WriteLine(Name);
        }

        var DepartmentEmployee = (from employee in employees
            join section in sections on employee.sectionId equals section.Id
            select new { EmployeeName = employee.Name, Section = section.Name });
        foreach (var deptemployee in DepartmentEmployee)
        {
            Console.WriteLine(deptemployee);
        }

        var _order = (from order in orderDetails
            where order.count > 2
            join product in products on order.productId equals product.Id
            select product
            );
        foreach (var order in _order.Distinct())
        {
            Console.WriteLine(order.Name);
        }

        var _users = from order in orders
            group order by order.userId
            into userGroup
            select new {UserId = userGroup.Key, Count = userGroup.Count() };
        foreach (var _user in _users)
        {
            Console.WriteLine(_user);
        }
        var topUser = (from _Order in orders
            group  _Order by _Order.userId into userGroup
                orderby userGroup.Count() descending
                select new { User = userGroup.Key, Count = userGroup.Count() }).First();
        var mostExpensiveOrder = (from detail in orderDetails
            join product in products on detail.productId equals product.Id
            group product.Price * detail.count by detail.orderId into orderGroup
            orderby orderGroup.Sum() descending
            select new
            {
                OrderId = orderGroup.Key,
                TotalPrice = orderGroup.Sum()
            }).First();
        var userId = orders.First(o => o.Id == mostExpensiveOrder.OrderId).userId;
        var UserName = users.First(u => u.Id == userId).Name;
        var top3Products = (from detail in orderDetails
            group detail by detail.productId into productGroup
            join product in products on productGroup.Key equals product.Id
            orderby productGroup.Sum(d => d.count) descending
            select new
            {
                ProductName = product.Name,
                TotalCount = productGroup.Sum(d => d.count)
            }).Take(3);
        var neverOrderedProducts = from product in products
            where !orderDetails.Any(detail => detail.productId == product.Id)
            select product;
        var Allusers = from user in users
            join order in orders on user.Id equals order.userId
            join detail in orderDetails on order.Id equals detail.orderId
            join product in products on detail.productId equals product.Id
            group product.Price * detail.count by user.Name into userGroup
            select new
            {
                UserName = userGroup.Key,
                TotalSpent = userGroup.Sum()
            };

    }
}