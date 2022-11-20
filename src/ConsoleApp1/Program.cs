using System.Linq;

using System.IO.Pipelines;
using System.Text;
using System.Text.Unicode;
using CommunityToolkit.HighPerformance;

var x = "Hello, World";

var b = x.AsMemory().AsBytes();

var k = b.Slice(0, 3);
var l = b.Slice(3, 3);
var m = b.Slice(6, 4);

var pipe = new Pipe();

var writer = pipe.Writer;

await writer.WriteAsync(k);
await writer.WriteAsync(l);
await writer.WriteAsync(m);

var ret = await pipe.Reader.ReadAsync();

var ret1 = Encoding.Unicode.GetString(ret.Buffer);


Console.WriteLine(ret1);
