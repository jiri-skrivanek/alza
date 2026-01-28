# Change List

1. Fixed ExampleTest.cs - need to wait until basket is updated. Otherwise it is unstable.
2. Fixed CartTest.cs - changed selector in HeaderContainer.cs
3. Fixed BaseTest.cs - need to reset IsLogged to false when driver is closed
4. Fixed ProductGridContainer.cs - need to repeat productCard scanning for the case that cards are not yet refreshed after category switch
5. Fixed CartTest.cs - added WaitBasketCount() because we need to wait for expected count.
6. Fixed typo in comment for GetBasketCount() method
7. Added AdminTest and all required helper methods

# TODO

1. Need to update test when the description field is no not required (bug #12345)
2. Need to use TestData.AdminTestProduct when it is clarified why only default products can be bought (bug #12346)
