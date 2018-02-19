# S-LThere project is mainly focus on “save and load” in game. 
The first and commonly used tech is prefab. This method is easy to use but hard to protect the data as the change of prefab also could cause the change of the instantiated object.
The second method is static script. This is easy to assess, but relay too much on the static script could make the too complicated to handle.
The third method is “DontDestroyOnLoad”. This method may be specific in Unity. When using this method, the object will not be destroyed when new scene is loaded. However, using this method could will need additional adjustment for both scene and script.
The last method I used is file. I think this is the most basic method should know. When a file is created, people could access data whenever they want. But this method requires file system.

My project.
Prefab
I do not use this method in this project until last moment. First create a player prefab and use “instantiate” to instantiate this prefab. In my project, I do it with simple with only the parameter of my object. With more parameter, designer could have more control of the relation with other game object. For example, when a transform data is added, this object will be instantiated as a child of the transform. It will make the object easy to manage.


#/br
Static Script& DontDestroyOnLoad
I use these two methods together to a “GameManager” is have the “DontDestroyOnLoad” method so the entire game will under this manager’s control. The issue is, every time I load the first scene, a new manager object will be created. So, it needs lots of adjustment. First, the newly created manager must be destroyed. Button UI should have addListern to make the onClike method work able, as the scene would will not have the GameManage instance when scene is loaded. 
As the GameManager is loaded just once, all the function in Start() and Awake() work just once. As a result, in my case, Slots get reference just once. I need to write addition code to check if the scene is newly load to set these value.


#/br
File
File is easy to use with code. However, BinaryFormatter do not have the ability to deal with vector3, at least in Unity, it doesn’t. So, I have to make the position stored in three different float value and assemble when file is loaded. It is important to manage the data, otherwise the result would be like mine. The Save and Load works but when it works at different scene, not good.
