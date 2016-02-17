//---COMPONENTS:
//CommentBox
////CommentList
//////Comment
////CommentForm

//------------------------------------------------------------------------------

var data = [
  { Author: "Daniel Lo Nigro", Text: "Hello ReactJS.NET World!" },
  { Author: "Pete Hunt", Text: "This is one comment" },
  { Author: "Jordan Walke", Text: "This is *another* comment" }
];

//adding properties --> props
var Comment = React.createClass({
    render: function () {
        var converter = new Showdown.converter();
        var rawMarkup = converter.makeHtml(this.props.children.toString());
        return (
          <div className="comment">
            <h2 className="commentAuthor">
                {this.props.author}
            </h2>
        <span dangerouslySetInnerHTML={{__html: rawMarkup}} />
          </div>
      );
    }
});

var CommentList = React.createClass({
    render: function () {
        var commentNodes = this.props.data.map(function (comment) {
            return (
                <Comment author={comment.Author }>
                    {comment.Text}
                </Comment>
            );
        });
        return (
          <div className="commentList">
              {commentNodes}
          </div>
      );
    }
});


var CommentForm = React.createClass({

    //when the user submits the form, we should clear it,
    //submit a request to the server, and refresh the list of comments
    handleSubmit: function (e) {

        //Call preventDefault() on the event to prevent the browser's
        //default action of submitting the form
        e.preventDefault();

        //We use the ref attribute to assign a name to a child component and this.refs
        // to reference the component. We can call getDOMNode()
        // on a component to get the native browser DOM element
        var author = this.refs.author.getDOMNode().value.trim();
        var text = this.refs.text.getDOMNode().value.trim();
        if (!text || !author) {
            return;
        }
        this.props.onCommentSubmit({ Author: author, Text: text });
        this.refs.author.getDOMNode().value = '';
        this.refs.text.getDOMNode().value = '';
        return;
    },

    render: function () {
        return (
      //attach an onSubmit handler to the form that clears the form fields
            //when the form is submitted with valid input
      <form className="commentForm" onSubmit={this.handleSubmit}>
        <input type="text" placeholder="Your name" ref="author" />
        <input type="text" placeholder="Say something..." ref="text" />
        <input type="submit" value="Post" />
      </form>
    );
    }
});

var CommentBox = React.createClass({

    //getInitialState() executes exactly once during the lifecycle of the component
    //and sets up the initial state of the component.
    getInitialState: function () {
        return { data: this.props.initialData };
    },

    //submit to the server and refresh the list
    handleCommentSubmit: function (comment) {
        var comments = this.state.data;
        var newComments = comments.concat([comment]);
        this.setState({ data: newComments });

        var data = new FormData();
        data.append('Author', comment.Author);
        data.append('Text', comment.Text);

        var xhr = new XMLHttpRequest();
        xhr.open('post', this.props.submitUrl, true);
        xhr.onload = function () {
            this.loadCommentsFromServer();
        }.bind(this);
        xhr.send(data);
    },

    //update state by GETting JSON from server using XMLHttpRequest API
    loadCommentsFromServer: function () {
        var xhr = new XMLHttpRequest();
        xhr.open('get', this.props.url, true);
        xhr.onload = function () {
            var data = JSON.parse(xhr.responseText);
            this.setState({ data: data });
        }.bind(this);
        xhr.send();
    },

    //componentDidMount is a method called automatically by React when a component is rendered.
    //The key to dynamic updates is the call to this.setState(). We replace the old array of
    //comments with the new one from the server and the UI automatically updates itself.
    componentDidMount: function () {
        this.loadCommentsFromServer();
        window.setInterval(this.loadCommentsFromServer, this.props.pollInterval);
    },

    //render returns a tree of React components that will eventually render to HTML.

    //props are immutable: they are passed from the parent and are "owned" by the parent.
    //To implement interactions, we introduce mutable state to the component.
    //this.state is private to the component and can be changed by calling this.setState().
    //When the state is updated, the component re-renders itself.
    render: function () {
        return (
          <div className="commentBox">
            <h1>Comments</h1>
              <CommentList data={this.state.data} />
              <CommentForm onCommentSubmit={this.handleCommentSubmit} />
          </div>
      );
    }
});
