Installation

1. Install dotnet library's
``sudo apt-get update
sudo apt-get install apt-transport-https
sudo apt-get update
sudo apt-get install dotnet-sdk-3.1``

2. Install Git
```sudo apt-get install git```

3. Download Floweum Node from github
```git clone https://github.com/floweum/floweum-node```

4. Go to the Floweum Node folder
```cd floweum-node```

2. Build Floweum Node librarys
Ubuntu 18.04 x64:
```dotnet build --runtime ubuntu.18.04-x64```
Ubuntu 16.04 x64:
```dotnet build --runtime ubuntu.16.04-x64```
Ubuntu 18.04 arm:
```dotnet build --runtime ubuntu.18.04-arm```
Ubuntu 16.04 arm:
```dotnet build --runtime ubuntu.16.04-arm```
