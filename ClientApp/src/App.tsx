import * as React from 'react';
import { Route } from 'react-router';
import { Chrome } from './components/Chrome';

import './custom.css'

export default (props: { children?: React.ReactNode }) => (
    <React.Fragment>
        <Chrome>
        </Chrome>
    </React.Fragment>
);
