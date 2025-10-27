
 using (var context = Fixture.CreateDbContext())

            {

                action(context);

            }
