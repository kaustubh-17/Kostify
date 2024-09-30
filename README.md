# Kostify

### Overview
**Kostify** is a platform that connects carton buyers and carton sellers. It is built using .NET MVC 5 and Entity Framework 6.

### Features
- Registration: Registration in either of 2 roles: buyer or seller
- Dashboard: Dashboard with basic details
- Unit Price Estimator (For buyer): Asks to give details like product, carton dimensions, carton material and show estimated unit price of carton
- Quotation Generator (For buyer): If buyer agrees with unit price, he can generate quotation after selecting a seller out of registered sellers
- My Quotations (For seller): Any seller can login and see the quotations that different buyers have requested them for, with option of 'Approve' or 'Reject'

### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/kaustubh-17/Kostify.git
   ```
2. Navigate to directory Kostify
3. Open the solution
4. Add reference of DAL (class library project) to CostEstimationSystem (MVC project)
5. Build the solution and run with IIS on localhost

### Usage

1. Select 'Signup' option and register as a seller
2. Select 'Signup' option again and register as a buyer
3. In the buyer signin, use estimator option to explore estimating unit prices of carton based on material and dimensions
4. Select a seller and generate quotation to submit
5. Login as seller again and go to 'My Quotations'
6. 'Approve' or 'Reject' the quotation of the recent buyer as required

### Link
[Kostify](http://costestimationsystem.bsite.net)
  
