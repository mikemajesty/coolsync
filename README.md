# Coolsync - Use multi thread easily 
<hr/>

### How to install

```
Install-Package coolsync
```

<br/>
<br/>

### How to use

``` C#
  private void start_task_click(object sender, EventArgs e)
  {
      Waiting sync = new Waiting();

      sync.Start(Execute);
      sync.CancelTask();
  }

  private void Execute()
  {
      for (int cont = 0; cont < 10000000; cont++)
      {
          textBox1.Text = cont.ToString();
      }
  }
```
<br/>
<br/>
<br/>
<br/>

### See operating

[![Click to see full video](https://i.imgsafe.org/c230969476.gif)](https://youtu.be/eGHWdPPsD4E)

<hr>

### License

It is available under the MIT license.
[License](https://opensource.org/licenses/mit-license.php)
