## 1. Cấu hình ActiveMQ Apache

- login.config

```java
    activemq {
        org.apache.activemq.jaas.PropertiesLoginModule required
        org.apache.activemq.jaas.properties.user="users.properties"
        org.apache.activemq.jaas.properties.group="groups.properties"
        reload=true;
    };
```

- groups.properties

```java
    #group_name=users_list
    admins=admin,teo
    users=ty
    dhcn=men
    guests=guest
```

- users.properties

```java
    #username=password
    admin=admin
    teo=123
    ty=456
    men=123

```
-  http://localhost:8161/admin/. -> Mở browsers

## 2. ActiveMQ Sender Java
- pom.xml
```xml
    <properties>
        <project.build.sourceEncoding>UTF-8</project.build.sourceEncoding>
        <maven.compiler.source>17</maven.compiler.source>
        <maven.compiler.target>17</maven.compiler.target>
    </properties>
    
    <build>
        <sourceDirectory>src</sourceDirectory>
        <plugins>
            <plugin>
                <artifactId>maven-compiler-plugin</artifactId>
                <version>3.8.1</version>
                <configuration>
                    <release>15</release>
                </configuration>
            </plugin>
        </plugins>
    </build>

    <dependencies>
        <!-- https://mvnrepository.com/artifact/org.apache.activemq/activemq-core -->
        <dependency>
            <groupId>org.apache.activemq</groupId>
            <artifactId>activemq-core</artifactId>
            <version>5.7.0</version>
        </dependency>

        <!-- https://mvnrepository.com/artifact/org.apache.activemq/activemq-core -->
        <dependency>
            <groupId>org.apache.activemq</groupId>
            <artifactId>activemq-core</artifactId>
            <version>5.7.0</version>
        </dependency>

        <!-- https://mvnrepository.com/artifact/log4j/log4j -->
        <dependency>
            <groupId>log4j</groupId>
            <artifactId>log4j</artifactId>
            <version>1.1.3</version>
        </dependency>

        <!-- https://mvnrepository.com/artifact/org.slf4j/slf4j-api -->
        <dependency>
            <groupId>org.slf4j</groupId>
            <artifactId>slf4j-api</artifactId>
            <version>2.0.0-alpha0</version>
        </dependency>

        <dependency>
            <groupId>javax.jms</groupId>
            <artifactId>javax.jms-api</artifactId>
            <version>2.0.1</version>
        </dependency>

        <!-- JAXB RI -->
        <dependency>
            <groupId>com.sun.xml.bind</groupId>
            <artifactId>jaxb-impl</artifactId>
            <version>2.3.4</version>
        </dependency>

    </dependencies>
```

- converter
```java
    public static String object2XML(Patient patient) {
        StringWriter sw = new StringWriter();
        JAXB.marshal(patient, sw);
        return sw.toString();
    }

    public static Patient xml2Object(String xml) {
        Patient patient = JAXB.unmarshal(new StringReader(xml), Patient.class);
        return patient;
    }
```
- entity -> implements Serializable
```java
    @XmlRootElement(name = "patient")
```
- send data:
```java
    //get context
    public static Context getContext() {
        try {
            BasicConfigurator.configure();

            Properties settings = new Properties();
            settings.setProperty(Context.INITIAL_CONTEXT_FACTORY, "org.apache.activemq.jndi.ActiveMQInitialContextFactory");
            settings.setProperty(Context.PROVIDER_URL, "tcp://localhost:61616");
            Context ctx = new InitialContext(settings);
            return ctx;
        } catch (NamingException e) {
            System.out.println(e.getMessage());
        }

        return null;
    }

    //config sender
    private void configSender() {
        private Connection conn;
        private Session session;
        private MessageProducer producer;

        try {
            Context ctx = getContext();
            ConnectionFactory factory = (ConnectionFactory) ctx.lookup("ConnectionFactory");
            Destination destination = (Destination) ctx.lookup("dynamicQueues/[name-queue]");
            conn = factory.createConnection("admin", "admin");
            session = conn.createSession(false, Session.AUTO_ACKNOWLEDGE);
            producer = session.createProducer(destination);
        } catch (JMSException | NamingException e) {
            System.err.println(e.getMessage());
        }
    }

    //send object convert to xml
    Patient patient = new Patient(maBN, soCMND, hoTen, diaChi);
    String patientXML = Converter.object2XML(patient);
    Message msg = session.createTextMessage(patientXML);
    producer.send(msg);
```

## 3. ActiveMQ Receiver C#
- add two libraries into references project C#
- model
```c#
    [Serializable]
    [XmlRoot("patient")]
```
- converter:
```c#
    public class XMLConverter<T>
    {
        public static string object2XML(T p)
        {
            string xml = "";
            XmlSerializer ser = new XmlSerializer(typeof(T));
            using (MemoryStream ms = new MemoryStream())
            {
                ser.Serialize(ms, p);
                ms.Position = 0;
                xml = new StreamReader(ms).ReadToEnd();
            }
            return xml;
        }

        public static Patient xml2Object(string xml)
        {
            var stringReader = new System.IO.StringReader(xml);
            var serializer = new XmlSerializer(typeof(Patient));
            return serializer.Deserialize(stringReader) as Patient;
        }

    }
```
- receiver data:
```c#
    public  IConnection getConnection()
    {
        Console.WriteLine("Connecting...");
        IConnectionFactory connectionFactory = new ConnectionFactory("tcp://localhost:61616");
        IConnection conn = connectionFactory.CreateConnection("admin", "admin");
        conn.Start();

        return conn;
    }

    //comsumer listening message queue send from Sender
    public void createConsumer()
    {
        Console.WriteLine("Receiving ...");
        conn = ConnectApache.getConnection();
        session = conn.CreateSession(AcknowledgementMode.AutoAcknowledge);
        ActiveMQQueue destination = new ActiveMQQueue("otgk");
        IMessageConsumer consumer = session.CreateConsumer(destination);
        consumer.Listener += Consumer_Listener;
    }

    
    // envent listening message ...
    private void Consumer_Listener(IMessage message)
    {
        if(message is ActiveMQTextMessage)
        {
            ActiveMQTextMessage objMessage = (ActiveMQTextMessage)message;
            Console.WriteLine("Receiver: " + objMessage.Text);
            
            Patient patient = XMLConverter<Patient>.xml2Object(objMessage.Text);
            patientList.Add(patient);
            lbPatients.Invoke(new Action(() => loadPatientIdToListBox(patientList)));
        }
    }
```