https://cairo-exp-relyk3.pythonanywhere.com/

This project is exploring logging unity information by wrapping the webgl game in a django server and then logging to that server with a POST message. The server then stores in a local sqlite db.

To deploy changes in unity:
1. Make your changes in Unity.
2. Build Unity as WebGL.
3. Make the following changes:
   a. Move Build/ and TemplateData/ into a new subdirectory next to index.html called static/
   b. In index.html, add {% load static %} at the top
   c. In index.html, change href="unity/TemplateData/favicon.ico: to href="{% static 'unity/TemplateData/favicon.ico' %}"
   d. In index.html, do the same with style.css
   e. In index.html, change var buildUrl = "Build" to var buildUrl = "static/Build"
4. Move the contents of this new directory into Django/mystudy/app/unity_build

Details:
Unity version: 2022.3.11f1
Python version: 3.12.1
