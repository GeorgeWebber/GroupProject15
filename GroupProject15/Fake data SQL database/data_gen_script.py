import pandas as pd
from faker import Faker
from collections import defaultdict
from sqlalchemy import create_engine

fake = Faker('en_GB')
fake_data = defaultdict(list)

for _ in range(100000):
    fake_data["Name"].append( fake.name() )
    fake_data["dob"].append( fake.date_of_birth() )
    fake_data["email"].append( fake.email() )
    fake_data["phone_number"].append( fake.cellphone_number() )
    fake_data["postcode"].append( fake.postcode() )

df_fake_data = pd.DataFrame(fake_data)


# posting data with user "root" and no password into database "fake_patient_data
# into "case" table
engine = create_engine('mysql://root:@localhost/fake_patient_data', echo=False)
df_fake_data.to_sql('case', con=engine,index=False)
