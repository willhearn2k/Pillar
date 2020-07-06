import React from 'react';
import Button from '@material-ui/core/Button';
import TextField from '@material-ui/core/TextField';
import Dialog from '@material-ui/core/Dialog';
import DialogActions from '@material-ui/core/DialogActions';
import DialogContent from '@material-ui/core/DialogContent';
import DialogContentText from '@material-ui/core/DialogContentText';
import DialogTitle from '@material-ui/core/DialogTitle';

interface Props {
	open: boolean;
	onClose: () => void;
}

class PlayerAddDialog extends React.Component<Props> {
	render() {
    	return (
			<Dialog open={this.props.open} onClose={this.props.onClose} aria-labelledby="form-dialog-title">
				<DialogTitle id="form-dialog-title">Add Player</DialogTitle>
				<DialogContent>
					<DialogContentText>
						Add new player details.
					</DialogContentText>
					<TextField autoFocus required margin="dense" id="knownas" label="Known As" type="text" fullWidth/>
					<TextField required  margin="dense" id="mobile" label="Mobile No." type="tel" fullWidth/>
					<TextField margin="dense" id="firstname" label="First Name" type="text" fullWidth/>
					<TextField margin="dense" id="surname" label="Surname" type="text" fullWidth/>
					<TextField margin="dense" id="email" label="Email" type="email" fullWidth/>
				</DialogContent>
				<DialogActions>
					<Button onClick={this.props.onClose} color="primary">Cancel</Button>
					<Button onClick={this.props.onClose} color="primary">Save</Button>
				</DialogActions>
			</Dialog>
		);
	}
}

export default PlayerAddDialog;
